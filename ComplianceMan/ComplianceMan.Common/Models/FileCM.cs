using System.ComponentModel.DataAnnotations;

namespace ComplianceMan.Common.Models
{
    public class FileCM
    {
        [Key]
        public int FileId { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }

        public int PolicyId { get; set; }
        public Policy Policy { get; set; }

        // Additional properties and relationships
    }
}
