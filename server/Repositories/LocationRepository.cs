

namespace inv_sys_react.Repositories;

public class LocationRepository
{
    private readonly IDbConnection _db;

    public LocationRepository(IDbConnection db)
    {
        _db = db;
    }

    internal List<Location> GetAllUserLocations(string userId)
    {
        string sql = @"
        SELECT
        perm.*,
        loc.*
        FROM permissionTies perm
        JOIN locations loc ON loc.id = perm.locationId
        WHERE perm.userId = @userId
        ;";
        List<Location> locations = _db.Query<Location, PermissionTie, Location>(sql, PermLocFlattener, new { userId }).ToList();
        return locations;
    }

    private Location PermLocFlattener(Location loc, PermissionTie perm)
    {
        return loc;
    }


}