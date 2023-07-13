using ComplianceMan.Data.Entity;

namespace ComplianceMan.Data.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<RoleDTO>> GetRoles();
        Task<int> GetRoleCount();

        Task UpdateUserRole(UserDTO user);

        Task<bool> CheckUserHasAccess(int userId, string permission);
    }
}
