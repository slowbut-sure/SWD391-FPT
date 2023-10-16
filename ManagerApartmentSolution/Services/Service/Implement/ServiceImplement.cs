using AutoMapper;
using Domain.Enums.Status;
using ManagerApartment.Models;
using Microsoft.Extensions.Hosting;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Request.ServiceRequest;
using Services.Models.Response.ServiceResponse;
using Services.Models.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class ServiceImplement : ServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ServiceImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseOfService> CreateService(RequestCreateService service)
        {
            var createService = _mapper.Map<Service>(service);
            createService.ServiceStatus = ServiceEnum.ACTIVE.ToString();

            _unitOfWork.Service.Add(createService);
            _unitOfWork.Save();
            return _mapper.Map<ResponseOfService>(createService);  
        }

        public async Task DeleteService(int serviceId)
        {
            var service = _unitOfWork.Service.GetById(serviceId);
            if (service is null)
            {
                throw new Exception("Can not found by" + serviceId);
            }
            service.ServiceStatus = ServiceEnum.INACTIVE.ToString();
            _unitOfWork.Service.Update(service);
            _unitOfWork.Save();
        }

        public async Task<List<ResponseOfService>> GetAllServices()
        {
            var services =  _unitOfWork.Service.GetAll().ToList();
            if (services is null)
            {
                throw new Exception("The service list is empty");
            }
            return _mapper.Map<List<ResponseOfService>>(services);
        }

        public async Task<ResponseOfService> GetServiceById(int id)
        {
            var service = await _unitOfWork.Service.GetServiceById(id);
            if (service is null)
            {
                throw new Exception("The service does not exist");
            }
            return _mapper.Map<ResponseOfService>(service);
        }

        public async Task<ResponseOfService> UpdateService(int serviceId, UpdateService updateService)
        {
            var service = _unitOfWork.Service.GetById(serviceId);
            if (service is null)
            {
                throw new Exception("Can not found ");
            }
            service.Code = updateService.ServiceCode;
            service.Price = updateService.ServicePrice;
            service.Unit = updateService.ServiceUnit;
            service.ServiceStatus = updateService.ServiceStatus;
            _unitOfWork.Service.Update(service);
            _unitOfWork.Save();
            return _mapper.Map<ResponseOfService>(service);
        }
    }
}
