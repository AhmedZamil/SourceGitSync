namespace ComplianceMan.Data.Entity
{
    public class PolicyFileDTO
    {
        public int PolicyId { get; set; }
        public PolicyDTO Policy { get; set; }

        public int FileId { get; set; }
        public FileDTO File { get; set; }
    }
}
