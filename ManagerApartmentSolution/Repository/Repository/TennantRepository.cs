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
    public class TennantRepository : GenericRepository<Tennant>, ITennantRepository
    {
        public TennantRepository(ManagerApartmentContext context) : base(context) { }

        public async Task<List<Tennant>> GetAllTennants()
        {
            var tennants = await _context.Tennants
                .Include(c => c.ContractDetail)
                .ToListAsync();
            return tennants;
        }

        public async Task<Tennant?> GetByEmail(string email)
        {
            return await _context.Tennants.FirstOrDefaultAsync(t => t.Email.Equals(email));
        }

        public async Task<Tennant> GetTennantById(int id)
        {
            return  _context.Tennants
                .Include(c => c.ContractDetail)
                .FirstOrDefault(s => s.TennantId == id);
        }

        public async Task<Tennant?> GetTennantByName(string name)
        {
            return await _context.Tennants.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
