using ComplianceMan.Data.Entity;

namespace ComplianceMan.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserDTO>> GetUsers();
        Task CreateUser(UserDTO user);
        Task<UserDTO> GetUserCompliance(int userId);

        Task<int> GetUserCount();

        Task<UserDTO> GetUserByUsernameAndPassword(string username, string password);
        Task<UserDTO> GetUserByUsername(string username);
        Task<UserDTO> GetUserByUserCode(string usercode);
        Task<UserDTO> GetUserByUserId(int userId);
    }
}
