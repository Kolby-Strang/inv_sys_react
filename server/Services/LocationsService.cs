using System.Reflection;
using Microsoft.AspNetCore.Http.HttpResults;

namespace inv_sys_react.Services;

public class LocationsService
{
    private readonly LocationsRepository _repo;
    private readonly PermissionTiesService _permService;
    private readonly PermissionLevelSettings _permissionLevel;

    public LocationsService(LocationsRepository repo, PermissionTiesService permService, PermissionLevelSettings permissionLevelSettings)
    {
        _repo = repo;
        _permService = permService;
        _permissionLevel = permissionLevelSettings;
    }

    internal Location ArchiveLocation(string userId, int locationId)
    {
        Location location = GetLocationById(locationId);
        if (location.IsArchived)
        {
            throw new Exception("This location has already been archived");
        }

        PermissionTie perms = _permService.GetPermissionTieByLocationAndUserId(userId, locationId);

        if (perms.PermissionLevel <= _permissionLevel.ArchiveLocation)//Check for perm level
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
        Location location = _repo.GetLocationById(locationId);
        if (location == null)//Check for existence
        {
            throw new Exception("Location does not exist.");
        }
        return location;
    }

    internal PermLoc CreateLocation(Location locInfo)
    {
        Location location = _repo.CreateLocation(locInfo);
        PermissionTie permTieInfo = new PermissionTie();
        permTieInfo.UserId = location.CreatorId;
        permTieInfo.LocationId = location.Id;
        permTieInfo.PermissionLevel = 0;
        PermissionTie perms = _permService.CreatePermissionTie(permTieInfo);
        PermLoc permLoc = PermLocFlattener(perms, location);
        return permLoc;
    }

    internal List<PermLoc> GetAllUserLocations(string userId)
    {
        List<PermLoc> allUserLocations = _repo.GetAllUserLocations(userId);
        return allUserLocations;
    }
    private PermLoc PermLocFlattener(PermissionTie perm, Location loc)
    {
        PermLoc fLocation = new PermLoc();
        fLocation.Id = perm.Id;
        fLocation.LocationId = loc.Id;
        fLocation.PermissionLevel = perm.PermissionLevel;
        fLocation.Name = loc.Name;
        fLocation.CreatorId = loc.CreatorId;
        fLocation.IsArchived = loc.IsArchived;
        fLocation.CreatedAt = loc.CreatedAt;
        fLocation.UpdatedAt = loc.UpdatedAt;

        return fLocation;
    }
    internal Location UpdateLocation(string userId, int locationId, string name)
    {
        PermissionTie perm = _permService.GetPermissionTieByLocationAndUserId(userId, locationId);
        if (perm.PermissionLevel <= _permissionLevel.UpdateLocation)
        {
            Location locInfo = new Location();
            locInfo.Id = locationId;
            locInfo.Name = name;
            return _repo.UpdateLocation(locInfo);
        }
        else
        {
            throw new Exception("You do not have the proper permission type for this action.");
        }
    }
}