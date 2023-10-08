using ManagerApartment.Models;
using Services.Models.Response.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface BillService
    {
        Task<List<ResponseOfBill>> GetAllBills();
        Task<ResponseOfBill> GetBillById(int id);
    }
}
