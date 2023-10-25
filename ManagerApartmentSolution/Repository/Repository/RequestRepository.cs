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
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<Request>> GetAllRequests()
        {
            var requests = await _context.Requests
                .Include(a => a.Apartment)
                .ToListAsync();
            return requests;
        }

        public async Task<Request> GetRequestById(int id)
        {
            return  _context.Requests
                .Include(a => a.Apartment)
                .FirstOrDefault(r => r.RequestId == id);
        }

        public async Task<List<Request>> GetStaffRequests()
        {
            var result = await _context.Requests.Include(r => r.Apartment)
                                        .Include(r => r.RequestDetails).ThenInclude(rds => rds.Package)
                                        .Include(r => r.AddOns).ToListAsync();
            return result;
        }   
    }
}
