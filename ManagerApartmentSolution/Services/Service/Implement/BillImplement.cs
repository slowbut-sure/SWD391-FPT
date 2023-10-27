using AutoMapper;
using Services.Interfaces;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.Response.Bill;
using Services.Models.Response.Response.TennantResponse;
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
        private readonly IBillRepository _billRepository;
        public BillImplement(IUnitOfWork unitOfWork, IMapper mapper, IBillRepository billRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _billRepository = billRepository;
        }
        public async Task<List<ResponseOfBill>> GetAllBills(int page, int pageSize, string sortOrder)
        {
            var bills = await _unitOfWork.Bill.GetAllBills();
            if (bills is null)
            {
                throw new Exception("The bill list is empty");
            }
            var billDTO = _mapper.Map<List<ResponseOfBill>>(bills);
            // Sắp xếp danh sách yêu cầu theo BookDateTime gần nhất
            if (sortOrder == "desc")
            {
                billDTO = billDTO.OrderByDescending(r => r.BookDateTime).ToList();
            }
            else
            {
                billDTO = billDTO.OrderBy(r => r.BookDateTime).ToList();
            }

            var startIndex = (page - 1) * pageSize;
            var pagedBills = billDTO.Skip(startIndex).Take(pageSize).ToList();

            return pagedBills;
        }

        public async Task<ResponseOfBill> GetBillById(int id)
        {
            var bill = await _billRepository.GetBillById(id);
            if (bill is null)
            {
                throw new Exception("The bill does not exist");
            }
            return _mapper.Map<ResponseOfBill>(bill);
        }
    }
}
