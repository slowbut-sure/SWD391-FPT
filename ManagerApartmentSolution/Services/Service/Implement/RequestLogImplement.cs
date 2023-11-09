using AutoMapper;
using Domain.Entity;
using Domain.Enums.Status;
using ManagerApartment.Models;
using Services.Helpers.Utils;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Request.RequestDetailRequest;
using Services.Models.Response;
using Services.Models.Response.Response.RequestRespponse;



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

        public async Task<DataResponse<ResponseOfRequestLog>> AssignStaffToRequestAsync(RqLogCreateRequest rqLogRequest)
        {
            DataResponse<ResponseOfRequestLog> res = new DataResponse<ResponseOfRequestLog>();

            Staff staff = await _unitOfWork.Staff.GetStaffByIdAsync(rqLogRequest.StaffId);
            if(staff == null)
            {
                res.Success = false;
                res.Message = "Staff assigned is not exist";
                return res;
            }

            RequestView request = await _unitOfWork.Request.GetRequestById(rqLogRequest.RequestId);
            if(request == null)
            {
                res.Success = false;
                res.Message = "Request assigned is not exist";
                return res;
            }

            var createRqLog = _mapper.Map<RequestLog>(rqLogRequest);
            createRqLog.Status = RequesLogEnum.PROCESSING.ToString();
            createRqLog.UpdateDate = Utils.GetClientDateTime();
            _unitOfWork.RequestLog.Add(createRqLog);
            bool suceess   = _unitOfWork.Save() == 1;
            if (!suceess)
            {
                res.Success = false;
                res.Message = "Assign Staff Failed";
            }
            res.Success = true;
            res.Message = "Assign Staff Sucessfully";
            res.Data = createRqLog;
            return res;
        }

        public async Task DeleteRequestLog(int rqLogId)
        {
            var rqLog = _unitOfWork.RequestLog.GetById(rqLogId);
            if (rqLog is null)
            {
                throw new Exception("Can not found by" + rqLogId);
            }
            rqLog.Status = RequesLogEnum.CANCELED.ToString();
            _unitOfWork.RequestLog.Update(rqLog);
            _unitOfWork.Save();
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

        public async Task<ResponseOfRequestLog> UpdateRequestLog(int id, UpdateRequestLog requestLog)
        {
            var rqLog = _unitOfWork.RequestLog.GetById(id);
            if (rqLog is null)
            {
                throw new Exception("Can not found " + id);
            }
            rqLog.RequestId = requestLog.RequestId;
            rqLog.MaintainItem = requestLog.rqLogMaintainItem;
            rqLog.Description = requestLog.ReqLogDescription;
            rqLog.Status = requestLog.RqLogStatus;
            _unitOfWork.RequestLog.Update(rqLog);
            _unitOfWork.Save();
            return _mapper.Map<ResponseOfRequestLog>(rqLog);
        }

    }
}
