using Services.Interfaces.IGenericRepository;
using ManagerApartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        Task<List<Service>> GetAllServices();
        Task<Service> GetServiceById(int id);
    }
}
