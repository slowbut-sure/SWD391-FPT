using ManagerApartment.Models;
using Services.Models.Response.RequestRespponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface RequestLogService
    {
        Task<List<ResponseOfRequestLog>> GetAllRequestLogs();
        Task<ResponseOfRequestLog> GetRequestLogById(int id);
    }
}
