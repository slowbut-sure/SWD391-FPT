using ManagerApartment.Models;
using Services.Models.Response;
using Services.Models.Response.Response;
using Services.Models.Response.Response.ApartmentResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface ApartmentService
    {
        Task<DataResponse<List<ResponseOfApartment>>> GetAllApartments(int page, int pageSize, string sortOrder);
        Task<DataResponse<ResponseOfApartment>> GetApartmentById(int id);
        Task<DataResponse<List<ResponseOfApartment>>> GetAparmentsByOwnerId(int ownerId);
    }
}
