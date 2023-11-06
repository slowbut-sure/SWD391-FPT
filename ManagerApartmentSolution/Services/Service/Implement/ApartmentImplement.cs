using AutoMapper;
using ManagerApartment.Models;
using Services.Interfaces;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response;
using Services.Models.Response.Response;
using Services.Models.Response.Response.ApartmentResponse;
using Services.Models.Response.Response.TennantResponse;
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
        private readonly IApartmentRepository _apartmentRepository;
        public ApartmentImplement(IUnitOfWork unitOfWork, IMapper mapper, IApartmentRepository apartmentRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
        }
        public async Task<DataResponse<List<ResponseOfApartment>>> GetAllApartments(int page, int pageSize, string sortOrder)
        {
            var response = new DataResponse<List<ResponseOfApartment>>();

            try
            {
                var apartments = await _unitOfWork.Apartment.GetAllApartments();
                if (apartments is null)
                {
                    response.Message = "The apartment list is empty";
                    response.Success = true;
                }
                var apartmentDTO = _mapper.Map<List<ResponseOfApartment>>(apartments);
                // Sắp xếp danh sách yêu cầu theo FromDate gần nhất
                if (sortOrder == "desc")
                {
                    apartmentDTO = apartmentDTO.OrderByDescending(r => r.FromDate).ToList();
                }
                else
                {
                    apartmentDTO = apartmentDTO.OrderBy(r => r.FromDate).ToList();
                }

                var startIndex = (page - 1) * pageSize;
                var pagedApartments = apartmentDTO.Skip(startIndex).Take(pageSize).ToList();

                response.Data = pagedApartments;
                response.Message = "List Apartments";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<DataResponse<List<ResponseOfApartment>>> GetAparmentsByOwnerId(int ownerId)
        {
            var response = new DataResponse<List<ResponseOfApartment>>();
            try
            {
                List<Apartment> ApartmentList = await _unitOfWork.Apartment.GetApartmentNameByOwnerId(ownerId);

                if (ApartmentList.Count == 0)
                {
                    response.Data = ApartmentList;
                    response.Success = true;
                    response.Message = "Owner has 0 Apartment";
                    return response;
                }
                response.Data = ApartmentList;
                response.Success = true;
                response.Message = "Get Apartment By Owner ID";
            }
            catch (Exception ex)
            {
                response.Message = response.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<DataResponse<ResponseOfApartment>> GetApartmentById(int id)
        {
            var response = new DataResponse<ResponseOfApartment>();

            try
            {
                var apartment = await _apartmentRepository.GetApartmentById(id);
                if (apartment is null)
                {
                    throw new Exception("Can not found by " + id);
                }
                response.Data = _mapper.Map<ResponseOfApartment>(apartment);
                response.Message = $"ApartmentId: {apartment.ApartmentId}";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
