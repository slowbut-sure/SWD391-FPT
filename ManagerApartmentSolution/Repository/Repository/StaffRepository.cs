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
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(ManagerApartmentContext context) : base(context) { }

        public async Task<List<Staff>> GetAllStaffs()
        {
            var staffs = await _context.Staff
                .ToListAsync();
            return staffs;
        }

        public async Task<Staff> GetStaffById(int id)
        {
            return await _context.Staff.FirstOrDefaultAsync(s => s.StaffId == id);
        }
    }
}
