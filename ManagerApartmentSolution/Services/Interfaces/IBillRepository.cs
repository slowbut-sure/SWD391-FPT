using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBillRepository : IGenericRepository<Bill>
    {
        Task<List<Bill>> GetAllBills();
        Task<Bill> GetBillById(int id);
    }
}
