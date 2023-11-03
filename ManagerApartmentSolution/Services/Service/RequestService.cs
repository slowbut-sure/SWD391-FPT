using Services.Models.Response;
using Services.Models.Response.Response;
using Services.Models.Response.Response.RequestRespponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface RequestService
    {
        Task<DataResponse<List<ResponseOfRequest>>> GetAllRequests(int page, int pageSize, string sortOrder);
        Task<ResponseOfRequest> GetRequestById(int id);

        Task<DataResponse<List<ResponseOfRequest>>> GetPendingAndProcessRequestsByStaffId(int staffId, int page, int pageSize, string sortOrder);

        Task DeleteRequest(int requestId);
    }
}
