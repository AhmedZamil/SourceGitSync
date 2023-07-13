using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Data.Entity
{
    public class UserPolicyDTO
    {
        [Key]
        public int UserPolicyId { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }

        public int PolicyId { get; set; }
        public PolicyDTO Policy { get; set; }

        public DateTime AcceptanceDate { get; set; }

        // Additional properties and relationships
    }
}
