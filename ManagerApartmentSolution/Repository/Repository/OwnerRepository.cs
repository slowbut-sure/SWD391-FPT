
using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<Owner>> GetAllOwners()
        {
            var owners = await _context.Owners
                .ToListAsync();
            return owners;
        }

        public async Task<Owner> GetOwnerById(int id)
        {
            return  _context.Owners.FirstOrDefault(r => r.OwnerId == id);
        }
    }
}
