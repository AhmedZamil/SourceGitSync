namespace ComplianceMan.Common.Models
{
    public class PolicyFile
    {
        public int PolicyId { get; set; }
        public Policy Policy { get; set; }

        public int FileId { get; set; }
        public FileCM File { get; set; }
    }
}
