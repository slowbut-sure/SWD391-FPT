using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
                .Include(r => r.Request)
                .Include(r => r.Package)
                .ToListAsync();
            return requestDetails;
        }

        public async Task<RequestDetail> GetRequestDetailById(int id)
        {
            return  _context.RequestDetails
                .Include(r => r.Request)
                .Include(r => r.Package)
                .FirstOrDefault(r => r.RequestDetailId == id);
        }
    }
}
