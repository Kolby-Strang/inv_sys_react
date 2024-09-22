

namespace inv_sys_react.Services;

public class LocationsService
{
    private readonly LocationsRepository _repo;

    public LocationsService(LocationsRepository repo)
    {
        _repo = repo;
    }

    internal Location CreateLocation(Location locInfo)
    {
        return _repo.CreateLocation(locInfo);
    }

    internal List<PermLoc> GetAllUserLocations(string userId)
    {
        List<PermLoc> allUserLocations = _repo.GetAllUserLocations(userId);
        return allUserLocations;
    }
}