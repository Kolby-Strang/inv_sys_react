namespace inv_sys_react.Services;

public class LocationService
{
    private readonly LocationRepository _repo; i

    public LocationService(LocationRepository repo)
    {
        _repo = repo;
    }

}