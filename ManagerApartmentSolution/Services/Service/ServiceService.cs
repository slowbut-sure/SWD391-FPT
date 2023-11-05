
using Services.Models.Request.ServiceRequest;
using Services.Models.Response.Response.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface ServiceService
    {
        Task<List<ResponseOfService>> GetAllServices();
        Task<ResponseOfService> GetServiceById(int id);
        Task<ResponseOfService> CreateService(RequestCreateService service);
        Task DeleteService(int serviceId);
        Task<ResponseOfService> UpdateService(int serviceId, UpdateService updateService);

    }
}
