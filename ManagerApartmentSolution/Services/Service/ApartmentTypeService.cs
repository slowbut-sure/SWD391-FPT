using ManagerApartment.Models;
using Services.Models.Response.Response.ApartmentResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface ApartmentTypeService
    {
        Task<List<ResponseOfApartmentType>> GetAllApartmentTypes();
        Task<ResponseOfApartmentType> GetApartmentTypeById(int id);
    }
}
