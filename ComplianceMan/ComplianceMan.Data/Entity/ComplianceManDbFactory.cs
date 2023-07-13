using ComplianceMan.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MiddleMan.Data.Entity
{
    public class ComplianceManDbFactory : IDesignTimeDbContextFactory<ComplianceManDbContext>
    {
        public ComplianceManDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ComplianceManDbContext> dbContextOptionsBuilder =
                new();
            return new ComplianceManDbContext(dbContextOptionsBuilder.Options);
        }

    }
}
