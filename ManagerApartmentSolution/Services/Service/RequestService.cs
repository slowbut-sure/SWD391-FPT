using Services.Models.Response.RequestRespponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface RequestService
    {
        Task<List<ResponseOfRequest>> GetAllRequests(int page, int pageSize, string sortOrder);
        Task<ResponseOfRequest> GetRequestById(int id);
        Task DeleteRequest(int requestId);
    }
}
