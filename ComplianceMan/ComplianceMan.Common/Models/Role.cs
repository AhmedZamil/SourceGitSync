using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Common.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public List<User> Users { get; set; } = new List<User>();

        public List<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

        // Additional properties and relationships
    }
}
