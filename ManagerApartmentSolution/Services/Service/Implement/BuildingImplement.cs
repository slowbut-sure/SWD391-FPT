using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.Response.BuildingResponse;
using Services.Models.Response.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class BuildingImplement : BuildingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BuildingImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ResponseOfBuilding>> GetAllBuildings()
        {
            var buildings =  _unitOfWork.Building.GetAll().ToList();
            if (buildings is null)
            {
                throw new Exception("The building list is empty");
            }
            return _mapper.Map<List<ResponseOfBuilding>>(buildings);
        }

        public async Task<ResponseOfBuilding> GetBuildingById(int id)
        {
            var building = await _unitOfWork.Building.GetBuildingById(id);
            if (building is null)
            {
                throw new Exception("The building does not exist");
            }
            return _mapper.Map<ResponseOfBuilding>(building);
        }
    }
}
