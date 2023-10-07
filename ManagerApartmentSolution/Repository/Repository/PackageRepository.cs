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
    public class PackageRepository : GenericRepository<Package>, IPackageRepository
    {
        public PackageRepository(ManagerApartmentContext context) : base(context) { }

        public async Task<List<Package>> GetAllPackages()
        {
            var packages = await _context.Packages
                .ToListAsync();
            return packages;
        }

        public async Task<Package> GetPackageById(int id)
        {
            return await _context.Packages.FirstOrDefaultAsync(r => r.PackageId == id);
        }
    }
}
