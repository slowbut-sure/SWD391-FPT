using ManagerApartment.Models;
using Services.Models.Response.Response.StaffResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface StaffDetailService
    {
        Task<List<ResponseOfStaffDetail>> GetAllStaffDetails();
        Task<ResponseOfStaffDetail> GetStaffDetailById(int id);
    }
}
