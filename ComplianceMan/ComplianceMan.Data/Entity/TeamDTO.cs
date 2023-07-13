using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Data.Entity
{
    public class TeamDTO
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public List<UserDTO> Users { get; set; } = new List<UserDTO>();
        public List<PolicyDTO> Policies { get; set; } = new List<PolicyDTO>();

        // Additional properties and relationships
    }
}
