using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.Response.AddOnResponse;
using Services.Models.Response.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class AddOnImplement : AddOnService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddOnImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseOfAddOn> GetAddOnById(int id)
        {
            var addOn = await _unitOfWork.AddOn.GetAddOnById(id);
            if (addOn is null)
            {
                throw new Exception("The addOn does not exist");
            }
            return _mapper.Map<ResponseOfAddOn>(addOn);
        }

        public async Task<List<ResponseOfAddOn>> GetAllAddOnss()
        {
            var addOns = await  _unitOfWork.AddOn.GetAllAddOns();
            if (addOns is null)
            {
                throw new Exception("The addOn list is empty");
            }
            return _mapper.Map<List<ResponseOfAddOn>>(addOns);
        }
    }
}
