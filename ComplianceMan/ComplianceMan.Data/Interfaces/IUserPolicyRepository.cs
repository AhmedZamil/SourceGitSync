using ComplianceMan.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace ComplianceMan.Data.Interfaces
{
    public interface IUserPolicyRepository
    {
        Task<List<UserPolicyDTO>> GetUserPolicies(int userId);
    }
}
