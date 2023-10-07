using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRequestLogRepository : IGenericRepository<RequestLog>
    {
        Task<List<RequestLog>> GetAllRequestLogs();
        Task<RequestLog> GetRequestLogById(int id);
    }
}
