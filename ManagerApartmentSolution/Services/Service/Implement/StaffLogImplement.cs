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
    public class StaffLogImplement : StaffLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StaffLogImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ResponseOfStaffLog>> GetAllStaffLogs()
        {
            var staffLogs =  _unitOfWork.StaffLog.GetAll().ToList();
            if (staffLogs is null)
            {
                throw new Exception("The staff log list is empty");
            }
            return _mapper.Map<List<ResponseOfStaffLog>>(staffLogs);
        }

        public async Task<ResponseOfStaffLog> GetStaffLogById(int id)
        {
            var staffLog = await _unitOfWork.StaffLog.GetStaffLogById(id);
            if (staffLog is null)
            {
                throw new Exception("The staff log does not exist");
            }
            return _mapper.Map<ResponseOfStaffLog>(staffLog);
        }
    }
}
