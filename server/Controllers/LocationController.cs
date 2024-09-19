namespace inv_sys_react.Controllers;

[ApiController]
[Route("[controller]")]

public class LocationController : ControllerBase
{
    private readonly Auth0Provider = _auth0Provider;
    private readonly LocationService = _locationService;

    public LocationController(Auth0Provider auth0Provider, LocationService locationService)
    {
        _auth0Provider = auth0Provider;
        _locationService = locationService;
    }
}