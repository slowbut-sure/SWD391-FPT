using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.ContractResponse;
using Services.Models.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class ContractImplement : ContractService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ContractImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ResponseOfContract>> GetAllContracts()
        {
            var contracts =  _unitOfWork.Contract.GetAll().ToList();
            if (contracts is null)
            {
                throw new Exception("The contract list is empty");
            }
            return _mapper.Map<List<ResponseOfContract>>(contracts);
        }

        public async Task<ResponseOfContract> GetContractById(int id)
        {
            var contract = await _unitOfWork.Contract.GetContractById(id);
            if (contract is null)
            {
                throw new Exception("The contract does not exist");
            }
            return _mapper.Map<ResponseOfContract>(contract);
        }
    }
}
