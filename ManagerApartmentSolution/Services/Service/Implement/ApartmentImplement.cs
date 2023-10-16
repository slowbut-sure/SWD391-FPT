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
    public class ApartmentImplement : ApartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ApartmentImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ResponseOfApartment>> GetAllApartments()
        {
            var apartments =  _unitOfWork.Apartment.GetAll().ToList();
            if (apartments is null)
            {
                throw new Exception("The apartment list is empty");
            }
            return _mapper.Map<List<ResponseOfApartment>>(apartments);
        }

        public async Task<ResponseOfApartment> GetApartmentById(int id)
        {
            var apartment = await _unitOfWork.Apartment.GetApartmentById(id);
            if (apartment is null)
            {
                throw new Exception("The apartment does not exist");
            }
            return _mapper.Map<ResponseOfApartment>(apartment);
        }
    }
}
