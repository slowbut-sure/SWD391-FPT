﻿using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITennantRepository : IGenericRepository<Tennant>
    {
        Task<List<Tennant>> GetAllTennants();
        Task<Tennant> GetTennantById(int id);
        Task<Tennant> GetTennantByName(string name);
        Task<Tennant> GetByEmail(string email);
    }
}
