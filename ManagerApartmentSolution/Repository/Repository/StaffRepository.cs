using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums.Role;
using Domain.Enums.Status;

namespace Repository.Repository
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(ManagerApartmentContext context) : base(context) { }

        public async Task<Staff> GetAccount(string staffAccount)
        {
            return _context.Staff.FirstOrDefault(ac => ac.Name.Equals(staffAccount));
        }

        public async Task<Staff> GetAccountByEmail(string email)
        {
            return _context.Staff.FirstOrDefault(ac => ac.Email.Equals(email));
        }

        public async Task<List<Staff>> GetAllStaffs()
        {
            var staffs = await _context.Staff
                .ToListAsync();
            return staffs;
        }

        public async Task<Staff> GetStaffById(int id)
        {
            return  _context.Staff.FirstOrDefault(s => s.StaffId == id);
        }

        public async Task<List<Staff>> GetStaffByName(string name)
        {
            return _context.Staff.Where(n => n.Name == name).ToList();
        }

        public async Task<List<Staff>> GetStaffsOnly()
        {
            return await _context.Staff
                        .Include(s => s.RequestLogs.Where(rl => rl.Status == ((int)RequesLogEnum.PENDING).ToString()))
                        .Where(s => s.Role == ((int)RolePositionStaff.STAFF).ToString())
                        .ToListAsync();
        }
    }
}
