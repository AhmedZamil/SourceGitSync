using ComplianceMan.Data.Entity;
using ComplianceMan.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplianceMan.Data.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly ComplianceManDbContext dbContext;

        public PolicyRepository(ComplianceManDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<PolicyDTO>> GetPolicies()
        {
            return await dbContext.Policies.ToListAsync();
        }

        public async Task CreatePolicy(PolicyDTO policy)
        {
            dbContext.Policies.Add(policy);
            await dbContext.SaveChangesAsync();
        }

        public async Task<PolicyDTO> GetPolicyDetails(int policyId)
        {
            return await dbContext.Policies.FindAsync(policyId);
        }

        public async Task<int> GetPolicyCount()
        {
            return await dbContext.Policies.CountAsync();
        }

        public async Task AcceptPolicy(int policyId,int userId)
        {
            // Implement the logic to get the current user's ID
            var CurrentUserId = 1;
            var userPolicy = new UserPolicyDTO
            {
                PolicyId = policyId,
                UserId = userId, 
                AcceptanceDate = DateTime.UtcNow
            };

            dbContext.UserPolicies.Add(userPolicy);
            await dbContext.SaveChangesAsync();
        }
    }
}
