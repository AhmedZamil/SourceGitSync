using AutoMapper;
using ComplianceMan.Common.Models;
using ComplianceMan.Data.Entity;
using ComplianceMan.Data.Interfaces;
using ComplianceMan.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Services.Services
{
    public class AzureAdAuthenticationService : IAzureAdAuthenticationService
    {
        //private readonly AuthenticationConfig _authConfig;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AzureAdAuthenticationService(IUserRepository userRepository, IMapper mapper)
        {
            //_authConfig = authConfig;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> HandleAzureAdAuthentication(string username, string accessToken)
        {
            var user = await _userRepository.GetUserByUsername(username);

            if (user == null)
            {
                // User does not exist in the local user database, create a new user record
                var newUser = new User
                {
                    UserName = username,
                    UserCode = accessToken
                    // Set additional user properties as needed
                };

                var userDTO = _mapper.Map<User, UserDTO>(newUser);
                await _userRepository.CreateUser(userDTO);
                var updateduser = _mapper.Map<UserDTO, User>(userDTO);
                return updateduser;
            }

            return _mapper.Map<UserDTO, User>(user);
        }
    }

}
