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
    public class StaffLogRepository : GenericRepository<StaffLog>, IStaffLogRepository
    {
        public StaffLogRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<StaffLog>> GetAllStaffLogs()
        {
            var staffLogs = await _context.StaffLogs
                .ToListAsync();
            return staffLogs;
        }

        public async Task<StaffLog> GetStaffLogById(int id)
        {
            return  _context.StaffLogs.FirstOrDefault(s => s.StaffLogId == id);
        }
    }
}
