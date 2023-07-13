using ComplianceMan.Data.Entity;
using ComplianceMan.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplianceMan.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ComplianceManDbContext dbContext;

        public RoleRepository(ComplianceManDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<RoleDTO>> GetRoles()
        {
            return await dbContext.Roles.Include(r=>r.RolePermissions).ToListAsync();
        }
        public async Task<int> GetRoleCount()
        {
            return await dbContext.Roles.CountAsync();
        }

        public async Task UpdateUserRole(UserDTO user)
        {
            var userEntity = await dbContext.Users.Include(u => u.UserPolicies).ThenInclude(up => up.Policy).FirstOrDefaultAsync(u => u.UserId == user.UserId);
            var role =  await dbContext.Roles.Include(r => r.RolePermissions).FirstOrDefaultAsync(r=> r.RoleId == user.RoleId);

            if (userEntity != null && role != null)
            {
                userEntity.Role = role;
                await dbContext.SaveChangesAsync();
            }


            //dbContext.Users.Update(user);
            //await dbContext.SaveChangesAsync();
        }

        //public async Task<bool> CheckUserHasAccess(int userId, string permission)
        //{
        //    var user = await dbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserId == userId);
        //    if (user != null && user.Role != null)
        //    {
        //        var rolePermissions = user.Role.RolePermissions;
        //        return rolePermissions.Permission.Contains(permission);
        //    }
        //    return false;
        //}

        public async Task<bool> CheckUserHasAccess(int userId, string permission)
        {
            var user = await dbContext.Users
                .Include(u => u.Role)
                .ThenInclude(r => r.RolePermissions)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user != null && user.Role != null)
            {
                var rolePermissions = user.Role.RolePermissions.Select(rp => rp.Permission);
                return rolePermissions.Contains(permission);
            }

            return false;
        }
    }
}
