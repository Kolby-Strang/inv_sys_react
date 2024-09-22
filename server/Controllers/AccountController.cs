using System.Diagnostics;

namespace inv_sys_react.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly LocationsService _locationsService;

  public AccountController(AccountService accountService, LocationsService locationsService, Auth0Provider auth0Provider)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _locationsService = locationsService;
  }

  [HttpGet]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateAccount(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  [Route("locations")]
  public async Task<ActionResult<List<PermLoc>>> GetAllUserLocations()
  {
    try
    {
      Account user = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<PermLoc> locations = _locationsService.GetAllUserLocations(user.Id);
      return Ok(locations);
    }
    catch (Exception err)
    {
      return BadRequest(err.Message);
    }
  }
}
