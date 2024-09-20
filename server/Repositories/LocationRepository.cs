
namespace inv_sys_react.Repositories;

public class LocationRepository
{
    private readonly IDbConnection _db;

    public LocationRepository(IDbConnection db)
    {
        _db = db;
    }

    internal async Task<List<Location>> GetAllUserLocations(string userId)
    {
        string sql = @"
        SELECT
        perm.*,
        loc.*
        FROM permissionTies perm
        JOIN locations loc ON loc.id = perm.locationId
        WHERE perms.userId = @userId
        ;";


    }
}