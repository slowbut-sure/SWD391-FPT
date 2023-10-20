using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Owner?> GetByEmail(string email)
        {
            return await _context.Owners.FirstOrDefaultAsync(r => r.Email.Equals(email));
        }

        public async Task<Owner> GetOwnerById(int id)
        {
            return  _context.Owners.FirstOrDefault(r => r.OwnerId == id);
        }

        public async Task<Owner?> GetOwnerByName(string name)
        {
            return await _context.Owners.FirstOrDefaultAsync(o => o.Name.Equals(name));
        }
    }
}
