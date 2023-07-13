using ComplianceMan.Data.Entity;
using ComplianceMan.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplianceMan.Data.Repositories
{
    public class UserPolicyRepository : IUserPolicyRepository
    {
        private readonly ComplianceManDbContext dbContext;

        public UserPolicyRepository(ComplianceManDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<UserPolicyDTO>> GetUserPolicies(int userId)
        {
            return await dbContext.UserPolicies
                .Include(u => u.Policy)
                .Include(p => p.User)
                .Where(up => up.UserId == userId) // Filter by userId
                .ToListAsync();
        }
    }
}
