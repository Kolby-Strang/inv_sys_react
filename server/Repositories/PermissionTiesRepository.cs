

namespace inv_sys_react.Repositories;

public class PermissionTiesRepository
{
    private readonly IDbConnection _db;
    public PermissionTiesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal PermissionTie CreatePermissionTie(PermissionTie permTieInfo)
    {
        string sql = @"
            INSERT INTO permissionTies
            (locationId, userId, permissionLevel)
            VALUES
            (@LocationId, @UserId, @PermissionLevel);

            SELECT * FROM permissionTies
            WHERE id = LAST_INSERT_ID()
        ;";
        return _db.Query<PermissionTie>(sql, permTieInfo).FirstOrDefault();
    }

    internal PermissionTie GetPermissionTieByLocationAndUserId(PermissionTie permTieInfo)
    {
        string sql = @"
            SELECT * FROM permissionTies
            WHERE 
            userId = @UserId AND locationId = @LocationId
        ;";

        return _db.Query<PermissionTie>(sql, permTieInfo).FirstOrDefault();
    }
}