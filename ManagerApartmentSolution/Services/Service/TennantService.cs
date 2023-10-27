using Services.Models.Request.TennantRequest;
using Services.Models.Response;
using Services.Models.Response.Response;
using Services.Models.Response.Response.StaffResponse;
using Services.Models.Response.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface TennantService
    {
        
        Task<DataResponse<List<ResponseOfTennant>>> GetAllTennants();
        Task<DataResponse<ResponseOfTennant>> GetTennantById(int id);
        Task<DataResponse<ResponseOfTennant>> CreateTennant(RequestCreateTennant tennantRequest);
        Task DeleteTennant(int tennantId);
        Task<DataResponse<ResponseOfTennant>> UpdateTennant(int id, UpdateTennant tennantRequest);
    }
}
