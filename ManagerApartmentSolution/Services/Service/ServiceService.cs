using ManagerApartment.Models;
using Services.Models.Response.ServiceResponse;
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
    }
}
