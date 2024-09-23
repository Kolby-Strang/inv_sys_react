

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
        return _repo.GetPermissionTieByLocationAndUserId(permTieInfo);
    }
}