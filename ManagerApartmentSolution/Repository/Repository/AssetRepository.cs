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
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        public AssetRepository(ManagerApartmentContext context)  : base(context) { }
        public async Task<List<Asset>> GetAllAssets()
        {
            var assets = await _context.Assets
                .ToListAsync();
            return assets;
        }

        public async Task<List<Asset>> GetAssetByApartmentId(int apartmentId)
        {
            return _context.Assets
                .Where(a => a.ApartmentId == apartmentId)
                .ToList();
        }

        public async Task<Asset> GetAssetById(int id)
        {
            return  _context.Assets.FirstOrDefault(r => r.AssetId == id);
        }

        public async Task<Asset> GetAssetHistoryByAssetId(int assetId)
        {
            return _context.Assets.FirstOrDefault(r => r.AssetId == assetId);
        }
    }
}
