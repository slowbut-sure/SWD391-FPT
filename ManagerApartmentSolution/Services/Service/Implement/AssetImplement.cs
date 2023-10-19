using AutoMapper;
using Domain.Enums.Status;
using ManagerApartment.Models;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Request.AssetRequest;
using Services.Models.Response.Asset;
using Services.Models.Response.ResponseAssetHistoryByAssetId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class AssetImplement : AssetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AssetImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteAsset(int assetId)
        {
            var asset = _unitOfWork.Asset.GetById(assetId);
            if (asset is null)
            {
                throw new Exception("Can not found by" + assetId);
            }
            asset.Status = AssetEnum.INACTIVE.ToString();
            _unitOfWork.Asset.Update(asset);
            _unitOfWork.Save();
        }

        public async Task<List<ResponseOfAsset>> GetAllAssets()
        {
            var assets =  _unitOfWork.Asset.GetAll().ToList();
            if (assets is null)
            {
                throw new Exception("The asset list is empty");
            }
            return _mapper.Map<List<ResponseOfAsset>>(assets);
        }

        public async Task<List<ResponseOfAsset>> GetAssetByApartmentId(int apartmentId)
        {
            var asset = await _unitOfWork.Asset.GetAssetByApartmentId(apartmentId);
            if (asset is null)
            {
                throw new Exception("The asset does not exist");
            }
            return _mapper.Map<List<ResponseOfAsset>>(asset);
        }

        public async Task<ResponseOfAsset> GetAssetById(int id)
        {
            var asset = await _unitOfWork.Asset.GetAssetById(id);
            if (asset is null)
            {
                throw new Exception("The asset does not exist");
            }
            return _mapper.Map<ResponseOfAsset>(asset);
        }

        public async Task<ResponseAssetHistory> GetAssetHistoryByAssetId(int assetId)
        {
            var asset = await _unitOfWork.Asset.GetAssetHistoryByAssetId(assetId);
            if (asset is null)
            {
                throw new Exception("The asset does not exist");
            }
            return _mapper.Map<ResponseAssetHistory>(asset);
        }

        public async Task<ResponseOfAsset> UpdateAsset(int id, UpdateAsset updateAsset)
        {
            var asset = _unitOfWork.Asset.GetById(id);
            if (asset is null)
            {
                throw new Exception("Can not found ");
            }
            asset.AssetHistoryId = updateAsset.AssetHistoryId;
            asset.ApartmentId = updateAsset.ApartmentId;
            asset.Name = updateAsset.AssetName;
            asset.Quantity = updateAsset.Quantity;
            asset.Description = updateAsset.AssetDescription;
            asset.ItemImage = updateAsset.ItemImage;
            asset.Status = updateAsset.AssetStatus;
            _unitOfWork.Asset.Update(asset);
            _unitOfWork.Save();
            return _mapper.Map<ResponseOfAsset>(asset);
        }
    }
}
