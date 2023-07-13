using ComplianceMan.Data.Entity;

namespace ComplianceMan.Data.Interfaces
{
    public interface ITeamRepository
    {
        Task<List<TeamDTO>> GetTeams();

        Task<List<TeamDTO>> GetTeamsByUser(int userId);
        Task CreateTeam(TeamDTO team);
        Task AssignUserToTeam(int userId, int teamId);
        Task<List<UserDTO>> GetTeamMembers(int teamId);
        Task<List<PolicyDTO>> GetTeamPolicies(int teamId);
        Task<TeamDTO> GetTeamCompliance(int teamId);
        Task AssignPoliciesToTeam(List<int> policyIds, int teamId);

        Task<int> GetTeamCount();
        Task<List<TeamDTO>> GetTeamsByPolicy(int policyId);
        Task UpdateTeam(TeamDTO team);
    }
}
