namespace OpenIddictApi;
public class Worker : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    public static readonly string Client_id = "8b170157-60ed-4cfb-b42d-656da19c2292";
    public static readonly string Client_secret = "53a7ffb2-3f85-426b-93b1-7c68fa64f57e";
    private readonly string Redirect_uri = "https://localhost:7029/";

    public Worker(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<OpenIddictApiServerContext>();
        await context.Database.EnsureCreatedAsync();

        var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

        if (await manager.FindByClientIdAsync(Client_id) is null)
        {
            var oia = new OpenIddictApplicationDescriptor
            {
                ClientId = Client_id,
                ClientSecret = Client_secret,
                DisplayName = "OpenIddict Api Server",
                Permissions =
                        {
                            Permissions.Endpoints.Authorization,
                            Permissions.Endpoints.Token,
                            Permissions.Endpoints.Device,
                            Permissions.Endpoints.Logout,
                            Permissions.Endpoints.Revocation,
                            Permissions.ResponseTypes.Code,
                            Permissions.GrantTypes.AuthorizationCode,
                            Permissions.GrantTypes.RefreshToken
                        }
            };
            oia.RedirectUris.Add(new Uri(Redirect_uri));
            await manager.CreateAsync(oia);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
