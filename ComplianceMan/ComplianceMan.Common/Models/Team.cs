using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Common.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public List<User> Users { get; set; } = new List<User>();
        public List<Policy> Policies { get; set; } = new List<Policy>();

        // Additional properties and relationships
    }
}
