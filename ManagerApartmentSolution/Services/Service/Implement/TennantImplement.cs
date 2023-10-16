using AutoMapper;
using Domain.Enums.Status;
using ManagerApartment.Models;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Request.TennantRequest;
using Services.Models.Response.ServiceResponse;
using Services.Models.Response.StaffResponse;
using Services.Models.Response.TennantResponse;
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
        public TennantImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseOfTennant> CreateTennant(RequestCreateTennant tennantRequest)
        {
            var createTennant = _mapper.Map<Tennant>(tennantRequest);
            createTennant.Status = TennantEnum.ACTIVE.ToString();

            _unitOfWork.Tennant.Add(createTennant);
            _unitOfWork.Save();
            return _mapper.Map<ResponseOfTennant>(createTennant);
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

        public async Task<List<ResponseOfTennant>> GetAllTennants()
        {
            var tennants =  _unitOfWork.Tennant.GetAll().ToList();
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

        public async Task<ResponseOfTennant> UpdateTennant(int id, UpdateTennant tennantRequest)
        {
            var tennant = _unitOfWork.Tennant.GetById(id);
            if (tennant is null)
            {
                throw new Exception("Can not found ");
            }
            tennant.Name = tennantRequest.TennantName;
            tennant.Email = tennantRequest.TennantEmail;
            tennant.Password = tennantRequest.Password;
            tennant.Phone = tennantRequest.TennantPhone;
            tennant.Address = tennantRequest.TennantAddress;
            tennant.Status = tennantRequest.TennantStatus;
            _unitOfWork.Tennant.Update(tennant);
            _unitOfWork.Save();
            return _mapper.Map<ResponseOfTennant>(tennant);
        }
    }
}
