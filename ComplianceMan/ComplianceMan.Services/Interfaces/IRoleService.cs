using ComplianceMan.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetRoles();
        Task<int> GetRoleCount();
        Task UpdateUserRole(User user);

        Task<bool> CheckUserHasAccess(int userId, string permission);
    }
}
