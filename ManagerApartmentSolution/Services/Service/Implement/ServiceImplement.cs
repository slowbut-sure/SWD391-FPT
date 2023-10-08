using AutoMapper;
using Services.Interfaces.IUnitOfWork;
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

        public async Task<List<ResponseOfService>> GetAllServices()
        {
            var services = await _unitOfWork.Service.GetAllServices();
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
    }
}
