﻿using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPackageRepository : IGenericRepository<Package>
    {
        Task<List<Package>> GetAllPackages();
        Task<Package> GetPackageById(int id);
    }
}
