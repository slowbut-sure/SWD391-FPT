using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAssetHistoryRepository : IGenericRepository<AssetHistory>
    {
        Task<List<AssetHistory>> GetAllAssetHistoris();
        Task<AssetHistory> GetAssetHistoryById(int id);
    }
}
