using Services.Models.Response.ContractResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface ContractService
    {
        Task<List<ResponseOfContract>> GetAllContracts(int page, int pageSize, string sortOrder);
        Task<ResponseOfContract> GetContractById(int id);
    }
}
