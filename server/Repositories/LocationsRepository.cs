



namespace inv_sys_react.Repositories;

public class LocationsRepository
{
    private readonly IDbConnection _db;

    public LocationsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Location ArchiveLocation(int locationId)
    {
        string sql = @"
            UPDATE 
        ;";//WORK HERE
        return _db.Query<Location>(sql, new { locationId }).FirstOrDefault();
    }

    internal Location CreateLocation(Location locationInfo)
    {
        string sql = @"
        INSERT INTO locations
        (name, creatorId)
        VALUES
        (@Name, @CreatorId);

        SELECT * FROM locations 
        WHERE id = LAST_INSERT_ID()
        ;";

        Location location = _db.Query<Location>(sql, locationInfo).FirstOrDefault();
        return location;
    }

    internal List<PermLoc> GetAllUserLocations(string userId)
    {
        string sql = @"
        SELECT
        perm.*,
        loc.*
        FROM permissionTies perm
        JOIN locations loc ON loc.id = perm.locationId
        WHERE perm.userId = @userId
        ;";
        List<PermLoc> locations = _db.Query<PermissionTie, Location, PermLoc>(sql, PermLocFlattener, new { userId }).ToList();
        return locations;
    }
    // THIS IS ALL WRONG AND SHOULD BE CONTAINED WITHIN A PERMISSION TIE SUITE AND ITS ALL BECAUSE OF THE FUCKING QUERY STATEMENT RETURNING THE PERMISSION TIE FIRST AND NOT SECOND.
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


}