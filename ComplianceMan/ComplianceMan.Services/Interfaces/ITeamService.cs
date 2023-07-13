using ComplianceMan.Common.Models;
using ComplianceMan.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Services.Interfaces
{
    public interface ITeamService
    {
        Task<List<Team>> GetTeams();
        Task CreateTeam(Team team);
        Task AssignUserToTeam(int userId, int teamId);
        Task<List<User>> GetTeamMembers(int teamId);
        Task<List<Policy>> GetTeamPolicies(int teamId);
        Task<Team> GetTeamCompliance(int teamId); // New method
        Task AssignPoliciesToTeam(List<int> policyIds, int teamId);

        Task<List<Team>> GetTeamsByUser(int userId);

        Task<int> GetTeamCount();
        Task<List<Team>> GetTeamsByPolicy(int policyId);
    }
}
