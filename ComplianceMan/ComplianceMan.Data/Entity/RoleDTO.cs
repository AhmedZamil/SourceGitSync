using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Data.Entity
{
    public class RoleDTO
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<UserDTO> Users { get; set; } = new List<UserDTO>();

        public List<RolePermissionDTO> RolePermissions { get; set; } = new List<RolePermissionDTO>();


        // Additional properties and relationships
    }
}
