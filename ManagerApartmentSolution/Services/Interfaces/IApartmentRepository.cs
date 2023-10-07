using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IApartmentRepository : IGenericRepository<Apartment>
    {
        Task<List<Apartment>> GetAllApartments();
        Task<Apartment> GetApartmentById(int id);
    }
}
