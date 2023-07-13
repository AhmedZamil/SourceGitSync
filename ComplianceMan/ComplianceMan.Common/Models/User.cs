using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Common.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }
        public string? UserCode { get; set; }
        public string? UserToken { get; set; }

        public List<UserPolicy> UserPolicies { get; set; } = new List<UserPolicy>();
        public List<Team> Teams { get; set; } = new List<Team>();

        public int RoleId { get; set; }
        public Role Role { get; set; }

        // Additional properties and relationships

    }
}
