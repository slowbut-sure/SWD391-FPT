using ManagerApartment.Models;
using Services.Models.Request.AssetRequest;
using Services.Models.Response.Response.Asset;
using Services.Models.Response.Response.ResponseAssetHistoryByAssetId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface AssetService
    {
        Task<List<ResponseOfAsset>> GetAllAssets();
        Task<ResponseOfAsset> GetAssetById(int id);
        Task<List<ResponseOfAsset>> GetAssetByApartmentId(int apartmentId);
        Task<ResponseAssetHistory> GetAssetHistoryByAssetId(int assetId);
        Task DeleteAsset(int assetId);
        Task<ResponseOfAsset> UpdateAsset(int id, UpdateAsset updateAsset);

    }
}
