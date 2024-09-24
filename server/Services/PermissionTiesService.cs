

namespace inv_sys_react.Services;

public class PermissionTiesService
{
    private readonly PermissionTiesRepository _repo;
    public PermissionTiesService(PermissionTiesRepository permissionTiesRepository)
    {
        _repo = permissionTiesRepository;
    }

    internal PermissionTie CreatePermissionTie(PermissionTie permTieInfo)
    {
        return _repo.CreatePermissionTie(permTieInfo);
    }

    internal PermissionTie GetPermissionTieByLocationAndUserId(string userId, int locationId)
    {
        PermissionTie permTieInfo = new PermissionTie();
        permTieInfo.LocationId = locationId;
        permTieInfo.UserId = userId;
        PermissionTie perm = _repo.GetPermissionTieByLocationAndUserId(permTieInfo);
        if (perm == null)//Check for existence
        {
            throw new Exception("Unauthorized. You do not have permission to access this location.");
        }
        return perm;
    }
}