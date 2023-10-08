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
    public class RequestLogRepository : GenericRepository<RequestLog>, IRequestLogRepository
    {
        public RequestLogRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<RequestLog>> GetAllRequestLogs()
        {
            var requestLogs = await _context.RequestLogs
                .ToListAsync();
            return requestLogs;
        }

        public async Task<RequestLog> GetRequestLogById(int id)
        {
            return await _context.RequestLogs.FirstOrDefaultAsync(r => r.RequestLogId == id);
        }
    }
}
