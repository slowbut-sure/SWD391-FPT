using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response;
using Services.Models.Response.Response.PackageResponse;
using Services.Models.Response.Response.TennantResponse;
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
        public async Task<PaginationResponse<List<ResponseOfPackage>>> GetAllPackages(int page, int pageSize, string sortOrder)
        {
            var response = new PaginationResponse<List<ResponseOfPackage>>();
            try
            {
                var packages = await _unitOfWork.Package.GetAllPackages();
                if (packages is null)
                {
                    response.Message = "The package list is empty";
                    return response;
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

                int temp = 0;
                if (packages.Count % pageSize == 0)
                    temp = packages.Count / pageSize;
                else
                    temp = (packages.Count / pageSize) + 1;

                response.Data = pagedRequests;
                response.Page = page;
                response.PageSize = pageSize;
                response.TotalPage = temp;
                response.Message = "List Packages";
            }
            catch (Exception ex) 
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
            }
            

            return response;
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
