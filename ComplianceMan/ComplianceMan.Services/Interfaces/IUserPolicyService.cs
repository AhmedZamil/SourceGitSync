using ComplianceMan.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Services.Interfaces
{
    public interface IUserPolicyService
    {
        Task<List<UserPolicy>> GetUserPolicies(int userId);
    }
}
