using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.Asset;
using Services.Models.Response.TennantResponse;
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
        public async Task<List<ResponseOfAsset>> GetAllAssets()
        {
            var assets = await _unitOfWork.Asset.GetAllAssets();
            if (assets is null)
            {
                throw new Exception("The asset list is empty");
            }
            return _mapper.Map<List<ResponseOfAsset>>(assets);
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
    }
}
