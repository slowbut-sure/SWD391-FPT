using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBuildingRepository : IGenericRepository<Building>
    {
        Task<List<Building>> GetAllBuildings();
        Task<Building> GetBuildingById(int id);
    }
}
