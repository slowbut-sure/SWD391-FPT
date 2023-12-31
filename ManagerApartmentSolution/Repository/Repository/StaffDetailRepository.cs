﻿using ManagerApartment.Models;
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
    public class StaffDetailRepository : GenericRepository<StaffDetail>, IStaffDetailRepository
    {
        public StaffDetailRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<StaffDetail>> GetAllStaffDetails()
        {
            var staffDetails = await _context.StaffDetails
                .Include(c => c.Staff)
                .Include(c => c.Service)
                .ToListAsync();
            return staffDetails;
        }

        public async Task<StaffDetail> GetStaffDetailById(int id)
        {
            return  _context.StaffDetails
                .Include(c => c.Staff)
                .Include(c => c.Service)
                .FirstOrDefault(s => s.StaffDetailId == id);
        }
    }
}
