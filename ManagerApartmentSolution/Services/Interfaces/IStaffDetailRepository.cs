using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStaffDetailRepository : IGenericRepository<StaffDetail>
    {
        Task<List<StaffDetail>> GetAllStaffDetails();
        Task<StaffDetail> GetStaffDetailById(int id);
    }
}
