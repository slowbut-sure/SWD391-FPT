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
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(ManagerApartmentContext context) : base(context) { }

        public async Task<List<Request>> GetAllRequests()
        {
            var requests = await _context.Requests
                .ToListAsync();
            return requests;
        }

        public async Task<Request> GetRequestById(int id)
        {
            return await _context.Requests.FirstOrDefaultAsync(r => r.RequestId == id);
        }
    }
}
