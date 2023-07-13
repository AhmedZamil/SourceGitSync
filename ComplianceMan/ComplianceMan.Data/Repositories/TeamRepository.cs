using ComplianceMan.Data.Entity;
using ComplianceMan.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplianceMan.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ComplianceManDbContext dbContext;

        public TeamRepository(ComplianceManDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<TeamDTO>> GetTeams()
        {
            return await dbContext.Teams.ToListAsync();
        }

        //public async Task CreateTeam(TeamDTO team)
        //{
        //    dbContext.Teams.Add(team);
        //    await dbContext.SaveChangesAsync();
        //}


        public async Task CreateTeam(TeamDTO team)
        {
            var teamEntity = new TeamDTO { TeamName = team.TeamName };

            dbContext.Teams.Add(teamEntity);
            await dbContext.SaveChangesAsync();

            foreach (var userEntity in team.Users)
            {
                var user = await dbContext.Users.FindAsync(userEntity.UserId);

                if (user != null)
                {
                    teamEntity.Users.Add(user);
                }
            }

            await dbContext.SaveChangesAsync();


            foreach (var policyEntity in team.Policies)
            {
                var policy = await dbContext.Policies.FindAsync(policyEntity.PolicyId);

                if (policy != null)
                {
                    teamEntity.Policies.Add(policy);
                }
            }

            await dbContext.SaveChangesAsync();
        }


        //public async Task CreateTeam(TeamDTO team)
        //{
        //    //foreach (var user in team.Users)
        //    //{
        //    //    dbContext.Entry(user).State = EntityState.Detached;
        //    //    team.Users.Add(user);
        //    //}


        //    dbContext.Teams.Add(team);
        //    await dbContext.SaveChangesAsync();
        //}

        //public async task createteam(teamdto team)
        //{
        //    //dbcontext.teams.add(team);

        //    //await dbcontext.savechangesasync();

        //    var teamentity = await dbcontext.teams.findasync(team.teamid);
        //    foreach (var userentity in team.users)
        //    {
        //        var user = await dbcontext.users.findasync(userentity.userid);

        //        if (user != null && team != null)
        //        {
        //            team.users.add(user);
        //            dbcontext.teams.add(team);
        //            await dbcontext.savechangesasync();
        //        }

        //    }




        //    //foreach (var user in team.Users)
        //    //{
        //    //    dbContext.Entry(user).State = EntityState.Detached;
        //    //}

        //    //dbContext.Teams.Add(team);
        //    //await dbContext.SaveChangesAsync();
        //}

        public async Task AssignUserToTeam(int userId, int teamId)
        {
            var user = await dbContext.Users.FindAsync(userId);
            var team = await dbContext.Teams.FindAsync(teamId);

            if (user != null && team != null)
            {
                team.Users.Add(user);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<UserDTO>> GetTeamMembers(int teamId)
        {
            var team = await dbContext.Teams.Include(t => t.Users).FirstOrDefaultAsync(t => t.TeamId == teamId);
            return team?.Users.ToList();
        }

        public async Task<TeamDTO> GetTeamCompliance(int teamId)
        {
            var team = await dbContext.Teams
                .Include(t => t.Policies)
                .ThenInclude(p => p.UserPolicies)
                .ThenInclude(up => up.User)
                .FirstOrDefaultAsync(t => t.TeamId == teamId);

            return team;
        }
        public async Task<List<PolicyDTO>> GetTeamPolicies(int teamId)
        {
            var team = await dbContext.Teams.Include(t => t.Policies).FirstOrDefaultAsync(t => t.TeamId == teamId);
            return team?.Policies.ToList();
        }

        //public async Task AssignPoliciesToTeam(List<int> policyIds, int teamId)
        //{
        //    var team = await dbContext.Teams.FindAsync(teamId);
        //    var policies = await dbContext.Policies.Where(p => policyIds.Contains(p.PolicyId)).ToListAsync();

        //    if (team != null && policies != null)
        //    {
        //        team.Policies.AddRange(policies);
        //        await dbContext.SaveChangesAsync();
        //    }
        //}

        public async Task AssignPoliciesToTeam(List<int> policyIds, int teamId)
        {
            var team = await dbContext.Teams
                .Include(t => t.Policies)
                .FirstOrDefaultAsync(t => t.TeamId == teamId);

            if (team != null)
            {
                var policies = await dbContext.Policies.Where(p => policyIds.Contains(p.PolicyId)).ToListAsync();
                team.Policies = policies;
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task<int> GetTeamCount()
        {
            return await dbContext.Teams.CountAsync();
        }

        public async Task<List<TeamDTO>> GetTeamsByPolicy(int policyId)
        {
            var teams = await dbContext.Teams
                .Include(t => t.Policies)
                .Where(t => t.Policies.Any(p => p.PolicyId == policyId))
                .ToListAsync();

            //return mapper.Map<List<Team>, List<TeamDTO>>(teams);
            return teams;
        }

        public async Task UpdateTeam(TeamDTO team)
        {
            dbContext.Teams.Update(team);
            await dbContext.SaveChangesAsync();
        }

        //public async Task<List<TeamDTO>> GetTeamsByUser(int userId)
        //{
        //    //var policies = await dbContext.Policies.Where(p => policyIds.Contains(p.PolicyId)).ToListAsync();
        //    var teams = await dbContext.Teams.Include(t => t.Users).Where(p => p.Users.All( u=> u.UserId== userId)).ToListAsync();
        //    return teams?.ToList();
        //}

        public async Task<List<TeamDTO>> GetTeamsByUser(int userId)
        {
            var user = await dbContext.Users.Include(u => u.Teams).FirstOrDefaultAsync(u => u.UserId == userId);
            return user?.Teams.ToList();
        }


    }
}
