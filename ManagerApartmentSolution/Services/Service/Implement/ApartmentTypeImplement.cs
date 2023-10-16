using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.ApartmentResponse;
using Services.Models.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class ApartmentTypeImplement : ApartmentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ApartmentTypeImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ResponseOfApartmentType>> GetAllApartmentTypes()
        {
            var apTypes = _unitOfWork.ApartmentType.GetAll().ToList();
            if (apTypes is null)
            {
                throw new Exception("The tennant list is empty");
            }
            return _mapper.Map<List<ResponseOfApartmentType>>(apTypes);
        }

        public async Task<ResponseOfApartmentType> GetApartmentTypeById(int id)
        {
            var apType = await _unitOfWork.ApartmentType.GetApartmentTypeById(id);
            if (apType is null)
            {
                throw new Exception("The apartmentType does not exist");
            }
            return _mapper.Map<ResponseOfApartmentType>(apType);
        }
    }
}
