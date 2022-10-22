using Microsoft.AspNetCore.Authentication.OpenIdConnect;

const string AUTHORIZATION_COOKIE = "Authorization";
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<OpenIddictApiServerContextKV>(options =>
{
    builder.Configuration.GetSection(nameof(OpenIddictApiServerContextKV)).BindConfigure(options);
});

builder.Services.AddControllers();
#region Swagger
builder.Services.AddEndpointsApiExplorer()
.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Plain Digital Signature Api",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Cookie,
        Description = "Please insert JWT with Bearer into field",
        Name = AUTHORIZATION_COOKIE,
        Type = SecuritySchemeType.OpenIdConnect
    });
    var oass = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    var oasr = new OpenApiSecurityRequirement { { oass, new string[] { } } };
    c.AddSecurityRequirement(oasr);
});
#endregion
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Policies

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(policyName: Permissions.Endpoints.Authorization, rolePolicy: Permissions.Endpoints.Authorization);
});


#endregion

#region OpenIddict

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OpenIddictApiServerContext>(options =>
{
    // Register the entity sets needed by OpenIddict.
    // Note: use the generic overload if you need to replace the default OpenIddict entities.
    options.UseOpenIddict();

});

builder.Services.AddOpenIddict()

    // Register the OpenIddict core components.
    .AddCore(options =>
    {
        // Configure OpenIddict to use the Entity Framework Core stores and models.
        // Note: call ReplaceDefaultEntities() to replace the default entities.
        options.UseEntityFrameworkCore()
               .UseDbContext<OpenIddictApiServerContext>();
    })

    // Register the OpenIddict server components.
    .AddServer(options =>
    {
        options.RequireProofKeyForCodeExchange();

        options.SetRefreshTokenLifetime(TimeSpan.FromDays(1));

        options.SetAuthorizationEndpointUris("/Connect/Authorize");

        options.SetTokenEndpointUris("/Connect/Token");

        options.SetUserinfoEndpointUris("/Connect/User");


        options.AllowAuthorizationCodeFlow();



        options.Configure(options => options.CodeChallengeMethods.Add(CodeChallengeMethods.Sha256));

        // Register the signing and encryption credentials.
        options.AddDevelopmentEncryptionCertificate()
               .AddDevelopmentSigningCertificate();

        // Register the ASP.NET Core host and configure the ASP.NET Core options.
        options.UseAspNetCore()
               .EnableTokenEndpointPassthrough();
    })

    // Register the OpenIddict validation components.
    .AddValidation(options =>
    {
        // Import the configuration from the local OpenIddict server instance.
        options.UseLocalServer();

        // Register the ASP.NET Core host.
        options.UseAspNetCore();
    });

// Register the worker responsible of seeding the database with the sample clients.
// Note: in a real world application, this step should be part of a setup script.
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenIddict().AddServer().UseAspNetCore().EnableAuthorizationEndpointPassthrough();

#endregion

var app = builder.Build();

#region Uses
app.Use(async (context, next) =>
{
    context.Request.Headers[AUTHORIZATION_COOKIE] =
    context.Request.Cookies[AUTHORIZATION_COOKIE];
    await next();
});
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor |
        ForwardedHeaders.XForwardedProto
})
.UseHttpsRedirection()
.UseAuthentication()
.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
    .UseSwaggerUI();
}
#endregion

app.MapControllers();



app.Run();
