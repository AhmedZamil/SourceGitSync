using ComplianceMan.Data.Entity;

namespace ComplianceMan.Data.Interfaces
{
    public interface IFileRepository
    {
        Task<List<FileDTO>> GetPolicyFiles(int policyId);
    }
}
