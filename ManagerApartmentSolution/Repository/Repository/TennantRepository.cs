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
    public class TennantRepository : GenericRepository<Tennant>, ITennantRepository
    {
        public TennantRepository(ManagerApartmentContext context) : base(context) { }

        public async Task<List<Tennant>> GetAllTennants()
        {
            var tennants = await _context.Tennants
                .Include(c => c.ContractDetail)
                .ToListAsync();
            return tennants;
        }

        public async Task<Tennant> GetTennantById(int id)
        {
            return  _context.Tennants
                .Include(c => c.ContractDetail)
                .FirstOrDefault(s => s.TennantId == id);
        }
    }
}
