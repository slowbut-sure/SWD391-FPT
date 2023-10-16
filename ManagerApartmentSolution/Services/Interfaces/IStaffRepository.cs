using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStaffRepository : IGenericRepository<Staff>
    {
        Task<List<Staff>> GetAllStaffs();
        Task<Staff> GetStaffById(int id);
        Task<Staff> GetAccount(string staffAccount);
        Task<Staff> GetAccountByEmail(string email);
    }
}
