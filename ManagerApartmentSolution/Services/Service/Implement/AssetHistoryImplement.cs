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
    public class AssetHistoryImplement : AssetHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AssetHistoryImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ResponseOfAssetHistory>> GetAllAssetHistoris()
        {
            var assHistorys =  _unitOfWork.AssetHistory.GetAll().ToList();
            if (assHistorys is null)
            {
                throw new Exception("The asset history list is empty");
            }
            return _mapper.Map<List<ResponseOfAssetHistory>>(assHistorys);
        }

        public async Task<ResponseOfAssetHistory> GetAssetHistoryById(int id)
        {
            var assHistory = await _unitOfWork.AssetHistory.GetAssetHistoryById(id);
            if (assHistory is null)
            {
                throw new Exception("The asset history does not exist");
            }
            return _mapper.Map<ResponseOfAssetHistory>(assHistory);
        }
    }
}
