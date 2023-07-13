using AutoMapper;
using ComplianceMan.Common.Models;
using ComplianceMan.Data.Entity;
using ComplianceMan.Data.Interfaces;
using ComplianceMan.Data.Repositories;
using ComplianceMan.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplianceMan.Services.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository fileRepository;
        private readonly IMapper mapper;

        public FileService(IFileRepository fileRepository, IMapper mapper)
        {
            this.fileRepository = fileRepository;
            this.mapper = mapper;
        }

        public async Task<List<FileCM>> GetPolicyFiles(int policyId)
        {
            var fileDTO = await fileRepository.GetPolicyFiles(policyId);
            var files = mapper.Map<List<FileDTO>, List<FileCM>>(fileDTO);
            return files;
        }
    }
}
