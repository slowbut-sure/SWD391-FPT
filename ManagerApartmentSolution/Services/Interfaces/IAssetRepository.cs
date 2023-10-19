using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAssetRepository : IGenericRepository<Asset>
    {
        Task<List<Asset>> GetAllAssets();
        Task<Asset> GetAssetById(int id);
        Task<Asset> GetAssetHistoryByAssetId(int assetId);
        Task<List<Asset>> GetAssetByApartmentId(int apartmentId);
    }
}
