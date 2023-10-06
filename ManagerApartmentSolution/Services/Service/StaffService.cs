using Services.Models.Response.StaffResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public interface StaffService
    {
        Task<List<ResponseAccountStaff>> GetAllStaffs();
        Task<ResponseAccountStaff> GetStaffById(int id);
    }
}
