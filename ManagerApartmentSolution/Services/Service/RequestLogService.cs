using ManagerApartment.Models;
using Services.Models.Request.RequestDetailRequest;
using Services.Models.Response.RequestRespponse;


namespace Services.Servicesss
{
    public interface RequestLogService
    {
        Task<List<ResponseOfRequestLog>> GetAllRequestLogs();
        Task<ResponseOfRequestLog> GetRequestLogById(int id);
        Task<ResponseOfRequestLog> CreateRequestLog(RqLogCreateRequest rqLogRequest);
        Task DeleteRequestLog(int rqLogId);
        Task<ResponseOfRequestLog> UpdateRequestLog(int id, UpdateRequestLog requestLog);
    }
}
