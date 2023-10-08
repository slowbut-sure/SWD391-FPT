using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.PackageResponse;
using Services.Models.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class PackageImplement : PackageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PackageImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ResponseOfPackage>> GetAllPackages()
        {
            var packages = await _unitOfWork.Package.GetAllPackages();
            if (packages is null)
            {
                throw new Exception("The package list is empty");
            }
            return _mapper.Map<List<ResponseOfPackage>>(packages);
        }

        public async Task<ResponseOfPackage> GetPackageById(int id)
        {
            var package = await _unitOfWork.Package.GetPackageById(id);
            if (package is null)
            {
                throw new Exception("The package does not exist");
            }
            return _mapper.Map<ResponseOfPackage>(package);
        }
    }
}
