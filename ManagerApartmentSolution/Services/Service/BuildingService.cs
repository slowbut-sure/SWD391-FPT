using ManagerApartment.Models;
using Services.Models.Response.Response.BuildingResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface BuildingService
    {
        Task<List<ResponseOfBuilding>> GetAllBuildings();
        Task<ResponseOfBuilding> GetBuildingById(int id);
    }
}
