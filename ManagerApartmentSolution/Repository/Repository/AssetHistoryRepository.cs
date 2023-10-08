using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class AssetHistoryRepository : GenericRepository<AssetHistory>, IAssetHistoryRepository
    {
        public AssetHistoryRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<AssetHistory>> GetAllAssetHistorys()
        {
            var assetHistorys = await _context.AssetHistories
                .ToListAsync();
            return assetHistorys;
        }

        public async Task<AssetHistory> GetAssetHistoryById(int id)
        {
            return await _context.AssetHistories.FirstOrDefaultAsync(r => r.AssetHistoryId == id);
        }
    }
}
