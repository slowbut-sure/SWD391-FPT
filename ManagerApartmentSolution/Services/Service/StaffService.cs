using Services.Models.Request.StaffRequest;
using Services.Models.Response.StaffResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface StaffService
    {
        Task<List<ResponseAccountStaff>> GetAllStaffs();
        Task<ResponseAccountStaff> GetStaffById(int id);
        Task<ResponseAccountStaff> CreateStaff(RequestCreateStaff staff);
        Task<ResponseAccountStaff> UpdateStaff(int staffId ,UpdateStaff updateStaff); 
        Task DeleteStaff(int staffId);
    }
}
