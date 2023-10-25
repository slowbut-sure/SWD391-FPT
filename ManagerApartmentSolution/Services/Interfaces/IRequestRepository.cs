﻿using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<List<Request>> GetAllRequests();
        Task<Request> GetRequestById(int id);
        Task<List<Request>> GetStaffRequests();
    }
}
