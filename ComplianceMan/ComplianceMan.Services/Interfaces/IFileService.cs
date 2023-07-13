using ComplianceMan.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Services.Interfaces
{
    public interface IFileService
    {
        Task<List<FileCM>> GetPolicyFiles(int policyId);
    }
}
