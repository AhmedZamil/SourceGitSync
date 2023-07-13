using ComplianceMan.Data.Entity;

namespace ComplianceMan.Data.Interfaces
{
    public interface IPolicyRepository
    {
        Task<List<PolicyDTO>> GetPolicies();
        Task CreatePolicy(PolicyDTO policy);
        Task<PolicyDTO> GetPolicyDetails(int policyId);
        Task<int> GetPolicyCount();
        Task AcceptPolicy(int policyId, int userId);
    }
}
