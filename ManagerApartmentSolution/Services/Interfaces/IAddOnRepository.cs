using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAddOnRepository : IGenericRepository<AddOn>
    {
        Task<List<AddOn>> GetAllAddOns();
        Task<AddOn> GetAddOnById(int id);
    }
}
