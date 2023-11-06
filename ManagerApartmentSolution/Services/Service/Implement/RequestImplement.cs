using AutoMapper;
using Domain.Entity;
using Domain.Enums.Status;
using ManagerApartment.Models;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response;
using Services.Models.Response.Response;
using Services.Models.Response.Response.RequestRespponse;
using Services.Models.Response.Response.StaffResponse;
using Services.Models.Response.Response.TennantResponse;
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

        public async Task DeleteRequest(int requestId)
        {
            var request = _unitOfWork.Request.GetById(requestId);
            if (request is null)
            {
                throw new Exception("Can not found by" + requestId);
            }
            request.ReqStatus = 1;
            _unitOfWork.Request.Update(request);
            _unitOfWork.Save();
        }

        public async Task<DataResponse<List<ResponseOfRequest>>> GetPendingAndProcessRequestsByStaffId(int staffId, int page, int pageSize, string sortOrder)
        {
            var rqs = await _unitOfWork.Request.GetPendingAndProcessingRequestByStaffId(staffId);
            if (rqs is null)
            {
                throw new Exception("The request list is empty");
            }
            var response = new DataResponse<List<ResponseOfRequest>>();
            var requestDtos = _mapper.Map<List<ResponseOfRequest>>(rqs);

            // Sắp xếp danh sách yêu cầu theo BookDateTime gần nhất
            if (sortOrder == "desc")
            {
                requestDtos = requestDtos.OrderByDescending(r => r.BookDateTime).ToList();
            }
            else
            {
                requestDtos = requestDtos.OrderBy(r => r.BookDateTime).ToList();
            }

            var startIndex = (page - 1) * pageSize;
            var pagedRequests = requestDtos.Skip(startIndex).Take(pageSize).ToList();
            response.Data = pagedRequests;
            response.Success = true;
            response.Message = "Successfully get requested";
            return response;
        }

        public async Task<DataResponse<List<ResponseOfRequest>>> GetAllRequests(int page, int pageSize, string sortOrder)
        {
            var response = new DataResponse<List<ResponseOfRequest>>();
            var rqs = await _unitOfWork.Request.GetAllRequests();
            if (rqs is null)
            {
                response.Data = null;
                response.Success = true;
                response.Message = "Empty requests";
                return response;
            }
            var requestDtos = _mapper.Map<List<ResponseOfRequest>>(rqs);

            // Sắp xếp danh sách yêu cầu theo BookDateTime gần nhất
            if (sortOrder == "desc")
            {
                requestDtos = requestDtos.OrderByDescending(r => r.BookDateTime).ToList();
            }
            else
            {
                requestDtos = requestDtos.OrderBy(r => r.BookDateTime).ToList();
            }

            var startIndex = (page - 1) * pageSize;
            var pagedRequests = requestDtos.Skip(startIndex).Take(pageSize).ToList();
            response.Data = pagedRequests;
            response.Success = true;
            response.Message = "Successfully get requested";
            return response;
        }

        public async Task<DataResponse<List<ResponseOfRequest>>> GetRequestsByApartment(int apartmentId)
        {
            var response = new DataResponse<List<ResponseOfRequest>>();
            try
            {
                var data = await _unitOfWork.Request.GetRequestsByApartmentId(apartmentId);
                if (data is null)
                {
                    response.Message = "Empty list";
                }
                else
                {
                    response.Data = _mapper.Map<List<ResponseOfRequest>>(data);
                    response.Message = "Requests by Apartment";
                    response.Success = true;
                }
            }
            catch (Exception ex) 
            {
                response.Message = "Something wrong; " + ex.Message;
                response.Success = false;
            }
           

            return response;
        }
    }
}
