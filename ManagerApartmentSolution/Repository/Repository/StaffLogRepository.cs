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
    public class StaffLogRepository : GenericRepository<StaffLog>, IStaffLogRepository
    {
        public StaffLogRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<StaffLog>> GetAllStaffLogs()
        {
            throw new NotImplementedException();
            //var staffLogs = await _context.StaffLogs
            //    .Include(s => s.Staff)
            //    .Include(s => s.RequestLog)
            //    .ToListAsync();
            //return staffLogs;
        }

        public async Task<StaffLog> GetStaffLogById(int id)
        {
            throw new NotImplementedException();
            //return _context.StaffLogs
            //    .Include(s => s.Staff)
            //    .Include(s => s.RequestLog)
            //    .FirstOrDefault(s => s.StaffLogId == id);
        }

        public async Task<List<StaffLog>> GetStaffLogByStaffId(int staffId)
        {
            throw new NotImplementedException();
            //return await _context.StaffLogs
            //    .Include(s => s.Staff)
            //    .Include(s => s.RequestLog)
            //    .Where(c => c.StaffId.Equals(staffId))
            //    .ToListAsync();
        }
    }
}
