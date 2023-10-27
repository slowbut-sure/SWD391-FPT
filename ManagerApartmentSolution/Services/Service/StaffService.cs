using Services.Models.Request.StaffRequest;
using Services.Models.Response;
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
        Task<DataResponse<List<ResponseAccountStaff>>> GetAllStaffs();
        Task<DataResponse<ResponseAccountStaff>> GetStaffById(int id);
        Task<DataResponse<ResponseAccountStaff>> CreateStaff(RequestCreateStaff staff);
        Task<DataResponse<ResponseAccountStaff>> UpdateStaff(int staffId ,UpdateStaff updateStaff); 
        Task DeleteStaff(int staffId);
        Task<DataResponse<List<ResponseAccountStaff>>> GetStaffByName(string name);
        Task<DataResponse<List<StaffRequestListResponse>>> GetRequets();
    }
}
