using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        Task<List<Owner>> GetAllOwners();
        Task<Owner> GetOwnerById(int id);
    }
}
