using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IApartmentTypeRepository : IGenericRepository<ApartmentType>
    {
        Task<List<ApartmentType>> GetAllApartmentTypes();
        Task<ApartmentType> GetApartmentTypeById(int id);
    }
}
