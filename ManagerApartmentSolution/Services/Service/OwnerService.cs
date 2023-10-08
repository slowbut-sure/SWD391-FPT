using ManagerApartment.Models;
using Services.Models.Response.OwnerResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface OwnerService
    {
        Task<List<ResponseOfOwner>> GetAllOwners();
        Task<ResponseOfOwner> GetOwnerById(int id);
    }
}
