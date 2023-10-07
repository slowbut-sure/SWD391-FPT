using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.StaffResponse;
using Services.Models.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Implement
{
    public class TennantImplement : TennantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TennantImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ResponseOfTennant>> GetAllTennants()
        {
            var tennants = await _unitOfWork.Tennant.GetAllTennants();
            if (tennants is null)
            {
                throw new Exception("The tennant list is empty");
            }
            return _mapper.Map<List<ResponseOfTennant>>(tennants);
        }

        public async Task<ResponseOfTennant> GetTennantById(int id)
        {
            var tennant = await _unitOfWork.Tennant.GetTennantById(id);
            if (tennant is null)
            {
                throw new Exception("The tennant does not exist");
            }
            return _mapper.Map<ResponseOfTennant>(tennant);
        }
    }
}
