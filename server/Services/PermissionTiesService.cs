
namespace inv_sys_react.Services;

public class PermissionTiesService
{
    private readonly PermissionTiesRepository _repo;
    public PermissionTiesService(PermissionTiesRepository permissionTiesRepository)
    {
        _repo = permissionTiesRepository;
    }

    internal PermissionTie GetPermissionTieByLocationAndUserId(string userId, int locationId)
    {
        throw new NotImplementedException();
    }
}