using ComplianceMan.Data.Entity;
using ComplianceMan.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplianceMan.Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ComplianceManDbContext dbContext;

        public FileRepository(ComplianceManDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<FileDTO>> GetPolicyFiles(int policyId)
        {

            return await dbContext.Files
                        .Include(t => t.Policy)
                        .Where(t => t.PolicyId == policyId)
                        .ToListAsync();
            //return await dbContext.Files.ToListAsync();
        }
    }
}
