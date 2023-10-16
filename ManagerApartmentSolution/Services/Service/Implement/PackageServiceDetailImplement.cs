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
    public class PackageServiceDetailImplement : PackageServiceDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PackageServiceDetailImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ResponseOfPackageServiceDetail>> GetAllPackageServiceDetails()
        {
            var pkServiceDetails =  _unitOfWork.PackageServiceDetail.GetAll().ToList();
            if (pkServiceDetails is null)
            {
                throw new Exception("The packeage service detail list is empty");
            }
            return _mapper.Map<List<ResponseOfPackageServiceDetail>>(pkServiceDetails);
        }

        public async Task<ResponseOfPackageServiceDetail> GetPackageServiceDetailById(int id)
        {
            var pkServiceDetail = await _unitOfWork.PackageServiceDetail.GetPackageServiceDetailById(id);
            if (pkServiceDetail is null)
            {
                throw new Exception("The packeage service detail does not exist");
            }
            return _mapper.Map<ResponseOfPackageServiceDetail>(pkServiceDetail);
        }
    }
}
