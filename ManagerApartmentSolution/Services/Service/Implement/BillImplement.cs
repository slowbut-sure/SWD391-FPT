using AutoMapper;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.Bill;
using Services.Models.Response.TennantResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss.Implement
{
    public class BillImplement : BillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BillImplement(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ResponseOfBill>> GetAllBills()
        {
            var bills = await _unitOfWork.Bill.GetAllBills();
            if (bills is null)
            {
                throw new Exception("The bill list is empty");
            }
            return _mapper.Map<List<ResponseOfBill>>(bills);
        }

        public async Task<ResponseOfBill> GetBillById(int id)
        {
            var bill = await _unitOfWork.Bill.GetBillById(id);
            if (bill is null)
            {
                throw new Exception("The bill does not exist");
            }
            return _mapper.Map<ResponseOfBill>(bill);
        }
    }
}
