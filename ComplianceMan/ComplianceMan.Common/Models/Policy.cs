using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Common.Models
{
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public string Description { get; set; }
        public List<UserPolicy> UserPolicies { get; set; } = new List<UserPolicy>();
        public List<Team> Teams { get; set; } = new List<Team>();
        public List<FileCM> Files { get; set; } = new List<FileCM>();

        // Additional properties and relationships
    }
}
