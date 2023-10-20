using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        public BillRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<Bill>> GetAllBills()
        {
            var bills = await _context.Bills
                .Include(r => r.RequestId)
                .ToListAsync();
            return bills;
        }

        public async Task<Bill> GetBillById(int id)
        {
            return  _context.Bills.FirstOrDefault(r => r.BillId == id);
        }
    }
}
