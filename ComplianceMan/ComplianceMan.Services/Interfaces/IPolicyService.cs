using ComplianceMan.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Services.Interfaces
{
    public interface IPolicyService
    {
        Task<List<Policy>> GetPolicies();
        Task CreatePolicy(Policy policy);
        Task<Policy> GetPolicyDetails(int policyId);
        Task<int> GetPolicyCount();

        Task AcceptPolicy(int policyId, int userId);
    }
}
