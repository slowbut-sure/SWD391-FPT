using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.StaffResponse;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class StaffImplement : StaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StaffImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ResponseAccountStaff>> GetAllStaffs()
        {
            var staffs = await _unitOfWork.Staff.GetAllStaffs();
            if(staffs is null)
            {
                throw new Exception("The staff list is empty");
            }
            return _mapper.Map<List<ResponseAccountStaff>>(staffs);
        }

        public async Task<ResponseAccountStaff> GetStaffById(int id)
        {
            var staff = await _unitOfWork.Staff.GetStaffById(id);
            if (staff is null)
            {
                throw new Exception("The staff does not exist");
            }
            return _mapper.Map<ResponseAccountStaff>(staff);
        }
    }
}
