using ComplianceMan.Data.Entity;
using ComplianceMan.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ComplianceMan.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ComplianceManDbContext dbContext;

        public UserRepository(ComplianceManDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await dbContext.Users.Include(u=>u.Role).ThenInclude(r=>r.RolePermissions).ToListAsync();
        }

        public async Task CreateUser(UserDTO user)
        {

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
        }

        //public async Task CreateUser(UserDTO user, ComplianceManDbContext dbContext, int maxRetries = 3)
        //{
        //    int retries = 0;
        //    bool success = false;

        //    while (!success && retries < maxRetries)
        //    {
        //        try
        //        {
        //            dbContext.Users.Add(user);
        //            await dbContext.SaveChangesAsync();
        //            success = true;
        //        }
        //        catch (ObjectDisposedException)
        //        {
        //            // Handle the ObjectDisposedException and recreate the context
        //            dbContext = dbContextFactory.CreateDbContext();
        //            retries++;
        //        }
        //    }

        //    if (!success)
        //    {
        //        // Handle the failure after the maximum number of retries
        //        // You can throw an exception or handle the failure scenario accordingly
        //    }
        //}


        public async Task<UserDTO> GetUserCompliance(int userId)
        {
            return await dbContext.Users.Include(u => u.UserPolicies).ThenInclude(up => up.Policy).FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<int> GetUserCount()
        {
            return await dbContext.Users.CountAsync();
        }

        public async Task<UserDTO> GetUserByUsernameAndPassword(string username, string password)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }

        public async Task<UserDTO> GetUserByUsername(string username)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<UserDTO> GetUserByUserCode(string usercode)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.UserCode == usercode);
        }

        public async Task<UserDTO> GetUserByUserId(int userId)
        {
            return await dbContext.Users.Include(u => u.UserPolicies).ThenInclude(up => up.Policy).FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}
