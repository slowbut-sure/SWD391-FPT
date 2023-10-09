using Services.Models.Request.TennantRequest;
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
        Task<ResponseOfTennant> CreateTennant(RequestCreateTennant tennantRequest);
        Task DeleteTennant(int tennantId);
        Task<ResponseOfTennant> UpdateTennant(int id, UpdateTennant tennantRequest);
    }
}
