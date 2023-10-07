﻿using ManagerApartment.Models;
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
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        public BillRepository(ManagerApartmentContext context) : base(context) { }

        public async Task<List<Bill>> GetAllBills()
        {
            var bills = await _context.Bills
                .ToListAsync();
            return bills;
        }

        public async Task<Bill> GetBillById(int id)
        {
            return await _context.Bills.FirstOrDefaultAsync(r => r.BillId == id);
        }
    }
}
