using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Common.Models
{
    public class UserPolicy
    {
        [Key]
        public int UserPolicyId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int PolicyId { get; set; }
        public Policy Policy { get; set; }

        public DateTime AcceptanceDate { get; set; }

        // Additional properties and relationships
    }
}
