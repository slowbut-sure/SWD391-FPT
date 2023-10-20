using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class AssetHistoryRepository : GenericRepository<AssetHistory>, IAssetHistoryRepository
    {
        public AssetHistoryRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<AssetHistory>> GetAllAssetHistoris()
        {
            var assetHistorys = await _context.AssetHistories
                .ToListAsync();
            return assetHistorys;
        }

        public async Task<AssetHistory> GetAssetHistoryById(int id)
        {
            return  _context.AssetHistories.FirstOrDefault(r => r.AssetHistoryId == id);
        }
    }
}
