using Domain.Entity;
using Services.Models.Request.RequestRequest;
using Services.Models.Request.TennantRequest;
using Services.Models.Response;
using Services.Models.Response.Response;
using Services.Models.Response.Response.RequestRespponse;
using Services.Models.Response.Response.TennantResponse;
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

        Task<DataResponse<List<ResponseOfRequest>>> GetPendingAndProcessRequestsByStaffId(int staffId, int page, int pageSize, string sortOrder);

        Task DeleteRequest(int requestId);

        Task<DataResponse<List<ResponseOfRequest>>> GetRequestsByApartment(int apartmentId);

        Task<DataResponse<List<ResponseOfRequest>>> GetRequestWithCurrentStatus(int page, int pageSize, string sortOrder);

        Task<DataResponse<List<ResponseOfRequest>>> GetAllRequestsByStaffId(int staffId, int page, int pageSize, string sortOrder);
        Task<DataResponse<List<ResponseOfRequest>>> GetAllRequestsByStatus(string status, int page, int pageSize, string sortOrder);
        Task<DataResponse<ResponseOfRequest>> CreateRequest(RequestCreateRequest request);
        Task<DataResponse<ResponseOfRequestDetail>> GetRequestDetail(int requestId);
        Task<DataResponse<List<ResponseOfRequest>>> GetRequestByOwnerId(int ownerId);
        Task<DataResponse<ResponseOfRequestLog>> UpdateRequest( RequestRequestLog log);
    }
}
