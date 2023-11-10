using AutoMapper;
using Domain.Entity;
using ManagerApartment.Models;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response;
using Services.Models.Response.Response.RequestRespponse;
using Services.Models.Response.Response.TennantResponse;
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
            var rqDetails = await _unitOfWork.RequestDetail.GetAllRequestDetails();
            if (rqDetails is null)
            {
                throw new Exception("The request detail list is empty");
            }
            return _mapper.Map<List<ResponseOfRequestDetail>>(rqDetails);
        }

      

        public async Task<DataResponse<ResponseOfRequestDetail>> GetRequestDetailByRequestId(int id)
        {
            RequestView rq = await _unitOfWork.Request.GetRequestViewById(id);
            var response = new DataResponse<ResponseOfRequestDetail>();

            if (rq is null)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Request is not existed";
                return response;
            }

            List<Service> serviceList = await _unitOfWork.Service.GetAddOnServiceByRequestId(id);
            RequestDetailView detail = new RequestDetailView
            {
                ApartmentId = rq.ApartmentId,
                ApartmentName = rq.ApartmentName,
                BookDateTime = rq.BookDateTime,
                EndDateTime = rq.EndDateTime,
                IsSequence = rq.IsSequence,
                Owner = rq.Owner,
                OwnerId = rq.OwnerId,
                PackageName = rq.PackageName,
                PackageRequestedId = rq.PackageRequestedId,
                ReqStatus = rq.ReqStatus,
                RequestDescription = rq.RequestDescription,
                RequestId = rq.RequestId,
                RequestSequence = rq.RequestSequence,
                AddOnList = serviceList,
                PackagePrice = rq.PackagePrice,
                ApartmentAddress = rq.ApartmentAddress
            };

            response.Data = detail;
            response.Success = true;
            response.Message = "Get Request Detail Successfully";

            return response;
        }

    }
}
