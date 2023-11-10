using Domain.Entity;
using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using Services.Models.Response.Response.RequestRespponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<List<RequestView>> GetAllRequests();
        Task<List<RequestView>> GetPendingAndProcessingRequestByStaffId(int staffId);
        Task<RequestView> GetRequestViewById(int id);

        Task<List<Request>> GetStaffRequests();

        Task<List<Request>> GetRequestsByApartmentId(int apartmentId);
        Task<List<RequestView>> GetRequestsByStaffId(int staffId);
        Task<List<RequestView>> GetRequestsByStatus(string status);
        Task<Request?> GetRequestDetailView(int requestId);
        Task<List<Request>> GetRequestsByOwnerId(int ownerId);
        Task<List<dynamic>> GetApartmentRequestCountByMonth();
    }
}
