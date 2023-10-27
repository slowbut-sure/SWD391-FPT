using AutoMapper;
using Domain.Enums.Status;
using ManagerApartment.Models;
using Services.Authentication;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Request.TennantRequest;
using Services.Models.Response;
using Services.Models.Response.Response;
using Services.Models.Response.Response.ServiceResponse;
using Services.Models.Response.Response.StaffResponse;
using Services.Models.Response.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class TennantImplement : TennantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthentication _authentication;
        public TennantImplement(IUnitOfWork unitOfWork, IMapper mapper, IAuthentication authentication)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authentication = authentication;
        }

        public async Task<DataResponse<ResponseOfTennant>> CreateTennant(RequestCreateTennant tennantRequest)
        {
            var response = new DataResponse<ResponseOfTennant>();

            try
            {
                var createTennant = _mapper.Map<Tennant>(tennantRequest);
                createTennant.Status = TennantEnum.ACTIVE.ToString();
                createTennant.Password = _authentication.Hash(tennantRequest.Password);
                _unitOfWork.Tennant.Add(createTennant);
                _unitOfWork.Save();
                response.Data = _mapper.Map<ResponseOfTennant>(createTennant);
                response.Message = "Create Successfully.";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task DeleteTennant(int tennantId)
        {
            var tennant = _unitOfWork.Tennant.GetById(tennantId);
            if (tennant is null)
            {
                throw new Exception("Can not found by" + tennantId);
            }
            tennant.Status = TennantEnum.INACTIVE.ToString();
            _unitOfWork.Tennant.Update(tennant);
            _unitOfWork.Save();
        }

        public async Task<DataResponse<List<ResponseOfTennant>>> GetAllTennants()
        {
            var response = new DataResponse<List<ResponseOfTennant>>();

            try
            {
                var tennants = _unitOfWork.Tennant.GetAll().ToList();
                if (tennants is null)
                {
                    throw new Exception("The tennant list is empty");
                }
                response.Data = _mapper.Map<List<ResponseOfTennant>>(tennants);
                response.Message = "List tennants";
                response.Success = true;
            }
            catch (Exception ex) 
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<DataResponse<ResponseOfTennant>> GetTennantById(int id)
        {
            var response = new DataResponse<ResponseOfTennant>();

            try
            {
                var tennant = await _unitOfWork.Tennant.GetTennantById(id);
                if (tennant is null)
                {
                    throw new Exception("The tennant does not exist");
                }
                response.Data = _mapper.Map<ResponseOfTennant>(tennant);
                response.Message = $"TennantId {tennant.TennantId}";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<DataResponse<ResponseOfTennant>> UpdateTennant(int id, UpdateTennant tennantRequest)
        {
            var response = new DataResponse<ResponseOfTennant>();

            try
            {
                var tennant = _unitOfWork.Tennant.GetById(id);
                if (tennant is null)
                {
                    response.Message = "Can not found ";
                    response.Success = false;
                    return response;
                }
                tennant.Name = tennantRequest.TennantName;
                tennant.Email = tennantRequest.TennantEmail;
                tennant.Password = _authentication.Hash(tennantRequest.Password);
                tennant.Phone = tennantRequest.TennantPhone;
                tennant.Address = tennantRequest.TennantAddress;
                tennant.Status = tennantRequest.TennantStatus;
                _unitOfWork.Tennant.Update(tennant);
                _unitOfWork.Save();
                response.Data = _mapper.Map<ResponseOfTennant>(tennant);
                response.Success = true;
                response.Message = "Update Successfully.";
            }
            catch(Exception ex) 
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
