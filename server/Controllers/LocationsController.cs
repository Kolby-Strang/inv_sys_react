using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace inv_sys_react.Controllers;

[ApiController]
[Route("[controller]")]

public class LocationsController : ControllerBase
{
    private readonly Auth0Provider _auth0Provider;
    private readonly LocationsService _locationsService;

    public LocationsController(Auth0Provider auth0Provider, LocationsService locationsService)
    {
        _auth0Provider = auth0Provider;
        _locationsService = locationsService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<PermLoc>> CreateLocation([FromBody] Location locInfo)
    {
        try
        {
            Account user = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            locInfo.CreatorId = user.Id;
            PermLoc location = _locationsService.CreateLocation(locInfo);
            return Ok(location);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpDelete("{locationId}")]
    [Authorize]
    public async Task<ActionResult<Location>> ArchiveLocation(int locationId)
    {
        try
        {
            Account user = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Location location = _locationsService.ArchiveLocation(user.Id, locationId);
            return Ok(location);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpPut("{locationId}")]
    [Authorize]
    public async Task<ActionResult<Location>> EditLocation(int locationId, [FromBody] Location locInfo)
    {
        try
        {
            Account user = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Location location = _locationsService.UpdateLocation(user.Id, locationId, locInfo.Name);
            return Ok(location);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
}