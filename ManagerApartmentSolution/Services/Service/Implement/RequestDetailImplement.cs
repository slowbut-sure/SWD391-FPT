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
    public class RequestDetailImplement : RequestDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RequestDetailImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ResponseOfRequestDetail>> GetAllRequestDetails()
        {
            var rqDetails =  _unitOfWork.RequestDetail.GetAll().ToList();
            if (rqDetails is null)
            {
                throw new Exception("The request detail list is empty");
            }
            return _mapper.Map<List<ResponseOfRequestDetail>>(rqDetails);
        }

        public async Task<ResponseOfRequestDetail> GetRequestDetailById(int id)
        {
            var rqDetail = await _unitOfWork.RequestDetail.GetRequestDetailById(id);
            if (rqDetail is null)
            {
                throw new Exception("The  request detail does not exist");
            }
            return _mapper.Map<ResponseOfRequestDetail>(rqDetail);
        }
    }
}
