using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response;
using Services.Models.Response.Response.OwnerResponse;
using Services.Models.Response.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class OwnerImplement : OwnerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OwnerImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DataResponse<List<ResponseOfOwner>>> GetAllOwners()
        {
            var response = new DataResponse<List<ResponseOfOwner>>();

            try
            {
                var owners = _unitOfWork.Owner.GetAll().ToList();
                if (owners is null)
                {
                    throw new Exception("The owner list is empty");
                }
                response.Data = _mapper.Map<List<ResponseOfOwner>>(owners);
                response.Message = "List owners";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<DataResponse<ResponseOfOwner>> GetOwnerById(int id)
        {
            var response = new DataResponse<ResponseOfOwner>();

            try
            {
                var owner = await _unitOfWork.Owner.GetOwnerById(id);
                if (owner is null)
                {
                    throw new Exception("The owner does not exist");
                }
                response.Data = _mapper.Map<ResponseOfOwner>(owner);
                response.Message = $"OwnerId {owner.OwnerId}";
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
