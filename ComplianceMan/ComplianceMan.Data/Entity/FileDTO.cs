using System.ComponentModel.DataAnnotations;

namespace ComplianceMan.Data.Entity
{
    public class FileDTO
    {
        [Key]
        public int FileId { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }

        public int PolicyId { get; set; }
        public PolicyDTO Policy { get; set; }

        // Additional properties and relationships
    }
}
