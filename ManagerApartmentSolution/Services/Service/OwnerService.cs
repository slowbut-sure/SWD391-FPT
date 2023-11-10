using ManagerApartment.Models;
using Services.Models.Response;
using Services.Models.Response.Response.OwnerResponse;
using Services.Models.Response.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface OwnerService
    {
        Task<DataResponse<List<ResponseOfOwner>>> GetAllOwners();
        Task<DataResponse<ResponseOfOwner>> GetOwnerById(int id);
    }
}
