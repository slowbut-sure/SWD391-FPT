using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class AssetHistoryRepository : GenericRepository<AssetHistory>, IAssetHistoryRepository
    {
        public AssetHistoryRepository(ManagerApartmentContext context) : base(context) { }
    }
}
