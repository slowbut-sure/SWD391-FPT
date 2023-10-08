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
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        public AssetRepository(ManagerApartmentContext context)  : base(context) { }
        public async Task<List<Asset>> GetAllAssets()
        {
            var assets = await _context.Assets
                .ToListAsync();
            return assets;
        }

        public async Task<Asset> GetAssetById(int id)
        {
            return await _context.Assets.FirstOrDefaultAsync(r => r.AssetId == id);
        }
    }
}
