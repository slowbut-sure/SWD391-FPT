using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class RequestDetailRepository : GenericRepository<RequestDetail>, IRequestDetailRepository
    {
        public RequestDetailRepository(ManagerApartmentContext context) : base(context) { }

        public async Task<List<RequestDetail>> GetAllRequestDetails()
        {
            var requestDetails = await _context.RequestDetails
                .ToListAsync();
            return requestDetails;
        }

        public async Task<RequestDetail> GetRequestDetailById(int id)
        {
            return await _context.RequestDetails.FirstOrDefaultAsync(r => r.RequestDetailId == id);
        }
    }
}
