﻿using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IContractDetailRepository : IGenericRepository<ContractDetail>
    {
        Task<List<ContractDetail>> GetAllContractDetails();
        Task<ContractDetail> GetContractDetailById(int id);
    }
}
