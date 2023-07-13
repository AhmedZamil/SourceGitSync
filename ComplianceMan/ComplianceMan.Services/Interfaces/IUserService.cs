using ComplianceMan.Common.Models;
using ComplianceMan.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task CreateUser(User user);
        Task<User> GetUserCompliance(int userId);
        Task<int> GetUserCount();
        Task<User> GetUserByUsernameAndPassword(string username, string password);
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByUserCode(string usercode);
    }
}
