namespace ComplianceMan.Data.Entity
{
    public class RolePermissionDTO
    {
        public int RolePermissionId { get; set; }
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
        public string Permission { get; set; }
    }
}
