using AutoMapper;
using ComplianceMan.Common.Models;
using ComplianceMan.Data.Entity;
using ComplianceMan.Data.Interfaces;
using ComplianceMan.Data.Repositories;
using ComplianceMan.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Services.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;
        private readonly IPolicyRepository policyRepository;
        private readonly IMapper mapper;

        public TeamService(ITeamRepository teamRepository, IPolicyRepository policyRepository, IMapper mapper)
        {
            this.teamRepository = teamRepository;
            this.policyRepository = policyRepository;
            this.mapper = mapper;
        }

        public async Task<List<Team>> GetTeams()
        {
            var teamsDTO = await teamRepository.GetTeams();
            var teams = mapper.Map<List<TeamDTO>, List<Team>>(teamsDTO);
            return teams;
        }

        //GetUsersTeams

        public async Task<List<Team>> GetTeamsByUser(int userId)
        {
            var teamsDTO = await teamRepository.GetTeamsByUser(userId);
            var teams = mapper.Map<List<TeamDTO>, List<Team>>(teamsDTO);
            return teams;
        }

        public async Task CreateTeam(Team team)
        {
            var teamDTO = mapper.Map<Team, TeamDTO>(team);
            await teamRepository.CreateTeam(teamDTO);
        }

        public async Task AssignUserToTeam(int userId, int teamId)
        {
            await teamRepository.AssignUserToTeam(userId, teamId);
        }

        public async Task<List<User>> GetTeamMembers(int teamId)
        {
            var membersDTO = await teamRepository.GetTeamMembers(teamId);
            var members = mapper.Map<List<UserDTO>, List<User>>(membersDTO);
            return members;
        }

        public async Task<List<Policy>> GetTeamPolicies(int teamId)
        {
            var policiesDTO = await teamRepository.GetTeamPolicies(teamId);
            var policies = mapper.Map<List<PolicyDTO>, List<Policy>>(policiesDTO);
            return policies;
        }

        public async Task<Team> GetTeamCompliance(int teamId)
        {
            var teamDTO = await teamRepository.GetTeamCompliance(teamId);
            var team = mapper.Map<TeamDTO, Team>(teamDTO);
            return team;
        }

        public async Task AssignPoliciesToTeam(List<int> policyIds, int teamId)
        {
            await teamRepository.AssignPoliciesToTeam(policyIds, teamId);
        }

        //public async Task AssignPoliciesToTeam(List<int> policyIds, int teamId)
        //{
        //    var policies = await policyRepository.GetPoliciesByIds(policyIds);
        //    var team = await teamRepository.GetTeamById(teamId);

        //    team.Policies.AddRange(policies);
        //    var teamDTO = mapper.Map<Team, TeamDTO>(team);

        //    await teamRepository.UpdateTeam(teamDTO);
        //}

        public async Task<int> GetTeamCount()
        {
            return await teamRepository.GetTeamCount();
        }

        // Existing methods

        public async Task<List<Team>> GetTeamsByPolicy(int policyId)
        {
            var teamsDTO = await teamRepository.GetTeamsByPolicy(policyId);
            var teams = mapper.Map<List<TeamDTO>, List<Team>>(teamsDTO);
            return teams;
        }
    }
}
