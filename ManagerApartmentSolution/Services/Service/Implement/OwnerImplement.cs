using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.Response.OwnerResponse;
using Services.Models.Response.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class OwnerImplement : OwnerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OwnerImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ResponseOfOwner>> GetAllOwners()
        {
            var owners =  _unitOfWork.Owner.GetAll().ToList();
            if (owners is null)
            {
                throw new Exception("The owner list is empty");
            }
            return _mapper.Map<List<ResponseOfOwner>>(owners);
        }

        public async Task<ResponseOfOwner> GetOwnerById(int id)
        {
            var owner = await _unitOfWork.Owner.GetOwnerById(id);
            if (owner is null)
            {
                throw new Exception("The owner does not exist");
            }
            return _mapper.Map<ResponseOfOwner>(owner);
        }
    }
}
