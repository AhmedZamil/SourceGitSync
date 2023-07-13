using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Data.Entity
{
    public class UserDTO
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }
        public string? UserCode { get; set; }
        public string? UserToken { get; set; }

        public List<UserPolicyDTO> UserPolicies { get; set; } = new List<UserPolicyDTO>();
        public List<TeamDTO> Teams { get; set; } = new List<TeamDTO>();

        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }

        // Additional properties and relationships

    }
}
