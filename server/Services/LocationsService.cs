using Microsoft.AspNetCore.Http.HttpResults;

namespace inv_sys_react.Services;

public class LocationsService
{
    private readonly LocationsRepository _repo;
    private readonly PermissionTiesService _permService;

    public LocationsService(LocationsRepository repo, PermissionTiesService permService)
    {
        _repo = repo;
        _permService = permService;
    }

    internal Location ArchiveLocation(string userId, int locationId)
    {
        GetLocationById(locationId);//Check for existence
        PermissionTie perms = _permService.GetPermissionTieByLocationAndUserId(userId, locationId);
        if (perms.PermissionLevel == 0)
        {
            return _repo.ArchiveLocation(locationId);
        }
        else
        {
            throw new Exception("Unauthorized. Need access type 0.");
        }
    }

    internal Location GetLocationById(int locationId)
    {
        throw new NotImplementedException();
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