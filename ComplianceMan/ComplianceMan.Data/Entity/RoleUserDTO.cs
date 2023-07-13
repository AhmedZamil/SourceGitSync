namespace ComplianceMan.Data.Entity
{
    public class RoleUserDTO
    {
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }

        public string UserId { get; set; }
        public UserDTO User { get; set; }
    }
}
