using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.RequestRespponse;
using Services.Models.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class RequestLogImplement : RequestLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RequestLogImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ResponseOfRequestLog>> GetAllRequestLogs()
        {
            var rqLogs = await _unitOfWork.RequestLog.GetAllRequestLogs();
            if (rqLogs is null)
            {
                throw new Exception("The request log list is empty");
            }
            return _mapper.Map<List<ResponseOfRequestLog>>(rqLogs);
        }

        public async Task<ResponseOfRequestLog> GetRequestLogById(int id)
        {
            var rqLog = await _unitOfWork.RequestLog.GetRequestLogById(id);
            if (rqLog is null)
            {
                throw new Exception("The request log does not exist");
            }
            return _mapper.Map<ResponseOfRequestLog>(rqLog);
        }

    }
}
