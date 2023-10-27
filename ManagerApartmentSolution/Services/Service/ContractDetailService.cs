using ManagerApartment.Models;
using Services.Models.Response.Response.ContractResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface ContractDetailService
    {
        Task<List<ResponseOfContractDetail>> GetAllContractDetails();
        Task<ResponseOfContractDetail> GetContractDetailById(int id);
    }
}
