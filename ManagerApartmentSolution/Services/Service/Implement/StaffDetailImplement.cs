using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.StaffResponse;
using Services.Models.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class StaffDetailImplement : StaffDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StaffDetailImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ResponseOfStaffDetail>> GetAllStaffDetails()
        {
            var staffDetails = await _unitOfWork.StaffDetail.GetAllStaffDetails();
            if (staffDetails is null)
            {
                throw new Exception("The staff Detail list is empty");
            }
            return _mapper.Map<List<ResponseOfStaffDetail>>(staffDetails);
        }

        public async Task<ResponseOfStaffDetail> GetStaffDetailById(int id)
        {
            var staffDetail = await _unitOfWork.StaffDetail.GetStaffDetailById(id);
            if (staffDetail is null)
            {
                throw new Exception("The staff Detail does not exist");
            }
            return _mapper.Map<ResponseOfStaffDetail>(staffDetail);
        }
    }
}
