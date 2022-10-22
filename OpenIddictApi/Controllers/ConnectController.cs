namespace OpenIddictApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ConnectController : ControllerBase
{
    private readonly IOpenIddictApplicationManager _applicationManager;
    private readonly IServiceProvider _serviceProvider;

    public ConnectController(IOpenIddictApplicationManager applicationManager, IServiceProvider serviceProvider)
    {
        _applicationManager = applicationManager;
        _serviceProvider = serviceProvider;
    }



    [HttpGet]
    public async Task<IActionResult> Authorize()
    {
        var request = HttpContext.GetOpenIddictServerRequest()!;
        if (!request.IsAuthorizationCodeFlow())
        {
            throw new NotImplementedException("The specified grant is not implemented.");
        }

        // Note: the client credentials are automatically validated by OpenIddict:
        // if client_id or client_secret are invalid, this action won't be invoked.

        var application = await _applicationManager.FindByClientIdAsync(request.ClientId!) ??
            throw new InvalidOperationException("The application cannot be found.");

        // Create a new ClaimsIdentity containing the claims that
        // will be used to create an id_token, a token or a code.
        var identity = new ClaimsIdentity(TokenValidationParameters.DefaultAuthenticationType, Claims.Name, Claims.Role);

        // Use the client_id as the subject identifier.
        identity.AddClaim(Claims.Subject,
            (await _applicationManager.GetClientIdAsync(application))!,
            Destinations.AccessToken, Destinations.IdentityToken);

        identity.AddClaim(Claims.Name,
            (await _applicationManager.GetDisplayNameAsync(application))!,
            Destinations.AccessToken, Destinations.IdentityToken);

        return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }


    [HttpPost]
    public async Task<IActionResult> Token()
    {
        var request = HttpContext.GetOpenIddictServerRequest()!;
        if (!request.IsAuthorizationCodeGrantType())
        {
            throw new NotImplementedException("The specified grant is not implemented.");
        }

        // Note: the client credentials are automatically validated by OpenIddict:
        // if client_id or client_secret are invalid, this action won't be invoked.

        var application = await _applicationManager.FindByClientIdAsync(request.ClientId!) ??
            throw new InvalidOperationException("The application cannot be found.");

        // Create a new ClaimsIdentity containing the claims that
        // will be used to create an id_token, a token or a code.
        var identity = new ClaimsIdentity(TokenValidationParameters.DefaultAuthenticationType, Claims.Name, Claims.Role);

        // Use the client_id as the subject identifier.
        identity.AddClaim(Claims.Subject,
            (await _applicationManager.GetClientIdAsync(application))!,
            Destinations.AccessToken, Destinations.IdentityToken);

        identity.AddClaim(Claims.Name,
            (await _applicationManager.GetDisplayNameAsync(application))!,
            Destinations.AccessToken, Destinations.IdentityToken);

        return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }

    [HttpPost]
    public async Task<IActionResult> User()
    {
        var request = HttpContext.GetOpenIddictServerRequest()!;
        if (!request.IsAuthorizationCodeGrantType())
        {
            throw new NotImplementedException("The specified grant is not implemented.");
        }

        // Note: the client credentials are automatically validated by OpenIddict:
        // if client_id or client_secret are invalid, this action won't be invoked.

        var application = await _applicationManager.FindByClientIdAsync(request.ClientId!) ??
            throw new InvalidOperationException("The application cannot be found.");

        // Create a new ClaimsIdentity containing the claims that
        // will be used to create an id_token, a token or a code.
        var identity = new ClaimsIdentity(TokenValidationParameters.DefaultAuthenticationType, Claims.Name, Claims.Role);

        // Use the client_id as the subject identifier.
        identity.AddClaim(Claims.Subject,
            (await _applicationManager.GetClientIdAsync(application))!,
            Destinations.AccessToken, Destinations.IdentityToken);

        identity.AddClaim(Claims.Name,
            (await _applicationManager.GetDisplayNameAsync(application))!,
            Destinations.AccessToken, Destinations.IdentityToken);

        return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }

}