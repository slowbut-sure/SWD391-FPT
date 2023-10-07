using Services.Models.Response.StaffResponse;
using Services.Models.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface TennantService
    {
        
        Task<List<ResponseOfTennant>> GetAllTennants();
        Task<ResponseOfTennant> GetTennantById(int id);
    }
}
