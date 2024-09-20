using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace inv_sys_react.Controllers;

[ApiController]
[Route("[controller]")]

public class LocationController : ControllerBase
{
    private readonly Auth0Provider _auth0Provider;
    private readonly LocationService _locationService;

    public LocationController(Auth0Provider auth0Provider, LocationService locationService)
    {
        _auth0Provider = auth0Provider;
        _locationService = locationService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<Location>>> GetAllUserLocations()
    {
        try
        {
            Account user = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = user.Id;
            List<Location> locations = await _locationService.GetAllUserLocations(userId);
            return Ok(locations);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
}