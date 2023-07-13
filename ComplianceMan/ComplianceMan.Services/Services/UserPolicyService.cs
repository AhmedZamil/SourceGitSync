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
    public class UserPolicyService : IUserPolicyService
    {
        private readonly IUserPolicyRepository userPolicyRepository;
        private readonly IMapper mapper;

        public UserPolicyService(IUserPolicyRepository userPolicyRepository, IMapper mapper)
        {
            this.userPolicyRepository = userPolicyRepository;
            this.mapper = mapper;
        }
        public async Task<List<UserPolicy>> GetUserPolicies(int userId)
        {
            var userPoliciesDTO = await userPolicyRepository.GetUserPolicies(userId);
            var userPolicies = mapper.Map<List<UserPolicyDTO>, List<UserPolicy>>(userPoliciesDTO);
            return userPolicies;
        }
    }
}
