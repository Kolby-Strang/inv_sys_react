
namespace inv_sys_react.Services;

public class LocationService
{
    private readonly LocationRepository _repo;

    public LocationService(LocationRepository repo)
    {
        _repo = repo;
    }

    internal async Task<List<Location>> GetAllUserLocations()
    {
        throw new NotImplementedException();
    }
}