using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.Response.ContractResponse;
using Services.Models.Response.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class ContractDetailImplement : ContractDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ContractDetailImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ResponseOfContractDetail>> GetAllContractDetails()
        {
            var ctDetails =  _unitOfWork.ContractDetail.GetAll().ToList();
            if (ctDetails is null)
            {
                throw new Exception("The contract detail list is empty");
            }
            return _mapper.Map<List<ResponseOfContractDetail>>(ctDetails);
        }

        public async Task<ResponseOfContractDetail> GetContractDetailById(int id)
        {
            var ctDetail = await _unitOfWork.ContractDetail.GetContractDetailById(id);
            if (ctDetail is null)
            {
                throw new Exception("The contract detail does not exist");
            }
            return _mapper.Map<ResponseOfContractDetail>(ctDetail);
        }
    }
}
