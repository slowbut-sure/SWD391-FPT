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
    public class AddOnRepository : GenericRepository<AddOn>, IAddOnRepository
    {
        public AddOnRepository(ManagerApartmentContext context): base(context)
        {
        }
        public async Task<AddOn> GetAddOnById(int id)
        {
            return  _context.AddOns
                .Include(r => r.Request)
                .Include(r => r.Service)
                .FirstOrDefault(r => r.AddOnId == id);
        }

        public async Task<List<AddOn>> GetAllAddOns()
        {
            var addOns = await _context.AddOns
                .Include(r => r.Request)
                .Include(r => r.Service)
                .ToListAsync();
            return addOns;
        }
    }
}
