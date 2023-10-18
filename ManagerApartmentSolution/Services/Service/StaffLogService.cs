using ManagerApartment.Models;
using Services.Models.Response.StaffResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface StaffLogService
    {
        Task<List<ResponseOfStaffLog>> GetAllStaffLogs();
        Task<ResponseOfStaffLog> GetStaffLogById(int id);

    }
}
