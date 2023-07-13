using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Data.Entity
{
    public class PolicyDTO
    {
        [Key]
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }

        public string Description { get; set; }
        public List<UserPolicyDTO> UserPolicies { get; set; } = new List<UserPolicyDTO>();
        public List<TeamDTO> Teams { get; set; } = new List<TeamDTO>();
        public List<FileDTO> Files { get; set; } = new List<FileDTO>();

        // Additional properties and relationships
    }
}
