using AutoMapper;
using ComplianceMan.Common.Models;
using ComplianceMan.Data.Entity;
using ComplianceMan.Data.Interfaces;
using ComplianceMan.Data.Repositories;
using ComplianceMan.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public RoleService(IRoleRepository roleRepository, IUserRepository userRepository, IMapper mapper)
        {
            this.roleRepository = roleRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<List<Role>> GetRoles()
        {

            //return await roleRepository.GetRoles();

            var rolesDTO = await roleRepository.GetRoles();
            var roles = mapper.Map<List<RoleDTO>, List<Role>>(rolesDTO);
            return roles;
        }

        public async Task<int> GetRoleCount()
        {
            return await roleRepository.GetRoleCount();

        }

        public async Task UpdateUserRole(User user)
        {
            var userEntity = mapper.Map<User, UserDTO>(user);
            await roleRepository.UpdateUserRole(userEntity);
        }

        public async Task<bool> CheckUserHasAccess(int userId, string permission)
        {
            return await roleRepository.CheckUserHasAccess(userId, permission); ;
        }


    }
}
