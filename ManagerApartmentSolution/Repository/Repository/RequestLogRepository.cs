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
    public class RequestLogRepository : GenericRepository<RequestLog>, IRequestLogRepository
    {
        public RequestLogRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<RequestLog>> GetAllRequestLogs()
        {
            var requestLogs = await _context.RequestLogs
                .Include(r => r.Request)
                .ToListAsync();
            return requestLogs;
        }

        public async Task<RequestLog> GetRequestLogById(int id)
        {
            return  _context.RequestLogs
                .Include(r => r.Request)
                .FirstOrDefault(r => r.RequestLogId == id);
        }

        public async Task<List<RequestLog>> GetRequestLogsByRequestId(int reqId)
        {
            return await _context.RequestLogs.Where(rl => rl.RequestId == reqId).ToListAsync();
        }

    }
}
