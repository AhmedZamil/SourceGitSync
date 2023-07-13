using AutoMapper;
using ComplianceMan.Common.Models;
using ComplianceMan.Data.Entity;
using ComplianceMan.Data.Interfaces;
using ComplianceMan.Data.Repositories;
using ComplianceMan.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly AuthenticationConfig _authConfig;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<List<User>> GetUsers()
        {
            var usersDTO = await userRepository.GetUsers();
            var users = mapper.Map<List<UserDTO>, List<User>>(usersDTO);
            return users;
        }

        public async Task CreateUser(User user)
        {

            var userDTO = mapper.Map<User, UserDTO>(user);
            await userRepository.CreateUser(userDTO);
        }

        public async Task<User> GetUserCompliance(int userId)
        {
            var userComplianceDTO = await userRepository.GetUserCompliance(userId);
            var userCompliance = mapper.Map<UserDTO, User>(userComplianceDTO);
            return userCompliance;
        }
        public async Task<int> GetUserCount()
        {
            return await userRepository.GetUserCount();
        }

        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            var userDTO = await userRepository.GetUserByUsernameAndPassword(username, password);
            var user = mapper.Map<UserDTO, User>(userDTO);
            return user;
            //return await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            //return await userRepository.GetUserByUsername(username);

            var userDTO = await userRepository.GetUserByUsername(username);
            var user = mapper.Map<UserDTO, User>(userDTO);
            return user;

        }

        public async Task<User> GetUserByUserCode(string usercode)
        {
            //return await userRepository.GetUserByUsername(username);

            var userDTO = await userRepository.GetUserByUserCode(usercode);
            var user = mapper.Map<UserDTO, User>(userDTO);
            return user;

        }



    }
}
