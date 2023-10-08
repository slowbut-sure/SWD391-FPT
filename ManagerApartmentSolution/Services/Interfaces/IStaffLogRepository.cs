using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStaffLogRepository : IGenericRepository<StaffLog>
    {
        Task<List<StaffLog>> GetAllStaffLogs();
        Task<StaffLog> GetStaffLogById(int id);
    }
}
