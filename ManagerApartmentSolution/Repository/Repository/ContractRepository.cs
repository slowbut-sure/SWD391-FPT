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
    public class ContractRepository : GenericRepository<Contract>, IContractRepository
    {
        public ContractRepository(ManagerApartmentContext context) : base(context) { }

        public async Task<List<Contract>> GetAllContracts()
        {
            var contracts = await _context.Contracts
                .ToListAsync();
            return contracts;
        }

        public async Task<Contract> GetContractById(int id)
        {
            return await _context.Contracts.FirstOrDefaultAsync(r => r.ContractId == id);
        }
    }
}
