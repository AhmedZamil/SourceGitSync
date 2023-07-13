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
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository policyRepository;
        private readonly IMapper mapper;

        public PolicyService(IPolicyRepository policyRepository, IMapper mapper)
        {
            this.policyRepository = policyRepository;
            this.mapper = mapper;
        }

        public async Task<List<Policy>> GetPolicies()
        {
            var policiesDTO = await policyRepository.GetPolicies();
            var policies = mapper.Map<List<PolicyDTO>, List<Policy>>(policiesDTO);
            return policies;
        }

        public async Task CreatePolicy(Policy policy)
        {
            var policyDTO = mapper.Map<Policy, PolicyDTO>(policy);
            await policyRepository.CreatePolicy(policyDTO);
        }

        public async Task<Policy> GetPolicyDetails(int policyId)
        {
            var policyDetailsDTO = await policyRepository.GetPolicyDetails(policyId);
            var policyDetails = mapper.Map<PolicyDTO, Policy>(policyDetailsDTO);
            return policyDetails;
        }

        public async Task<int> GetPolicyCount()
        {
            return await policyRepository.GetPolicyCount();
        }

        public async Task AcceptPolicy(int policyId,int userId)
        {
            await policyRepository.AcceptPolicy(policyId,userId);
        }
    }
}
