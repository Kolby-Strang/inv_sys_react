
namespace inv_sys_react.Services;

public class LocationService
{
    private readonly LocationRepository _repo;

    public LocationService(LocationRepository repo)
    {
        _repo = repo;
    }

    internal List<PermLoc> GetAllUserLocations(string userId)
    {
        List<PermLoc> allUserLocations = _repo.GetAllUserLocations(userId);
        return allUserLocations;
    }
}