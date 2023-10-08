using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.RequestRespponse;
using Services.Models.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class RequestImplement : RequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RequestImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ResponseOfRequest>> GetAllRequests()
        {
            var rqs = await _unitOfWork.Request.GetAllRequests();
            if (rqs is null)
            {
                throw new Exception("The request list is empty");
            }
            return _mapper.Map<List<ResponseOfRequest>>(rqs);
        }

        public async Task<ResponseOfRequest> GetRequestById(int id)
        {
            var rq = await _unitOfWork.Request.GetRequestById(id);
            if (rq is null)
            {
                throw new Exception("The request does not exist");
            }
            return _mapper.Map<ResponseOfRequest>(rq);
        }
    }
    }
}
