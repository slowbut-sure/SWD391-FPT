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
    public class ContractRepository : GenericRepository<Contract>, IContractRepository
    {
        public ContractRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<Contract>> GetAllContracts()
        {
            var contracts = await _context.Contracts
                .Include(a => a.ApartmentId)
                .Include(a => a.ContractDetailId)
                .ToListAsync();
            return contracts;
        }

        public async Task<Contract> GetContractById(int id)
        {
            return  _context.Contracts.FirstOrDefault(r => r.ContractId == id);
        }
    }
}
