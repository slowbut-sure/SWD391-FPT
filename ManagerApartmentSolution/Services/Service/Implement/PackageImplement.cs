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
        public async Task<List<ResponseOfPackage>> GetAllPackages(int page, int pageSize, string sortOrder)
        {
            var packages = await _unitOfWork.Package.GetAllPackages();
            if (packages is null)
            {
                throw new Exception("The package list is empty");
            }
            var packageDTO = _mapper.Map<List<ResponseOfPackage>>(packages);
            // Sắp xếp danh sách yêu cầu theo package tang dan
            if (sortOrder == "desc")
            {
                packageDTO = packageDTO.OrderByDescending(r => r.PackageId).ToList();
            }
            else
            {
                packageDTO = packageDTO.OrderBy(r => r.PackageId).ToList();
            }

            var startIndex = (page - 1) * pageSize;
            var pagedRequests = packageDTO.Skip(startIndex).Take(pageSize).ToList();

            return pagedRequests;
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
