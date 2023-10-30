using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Models.Response.Response.RequestRespponse;
using Domain.Entity;
using Microsoft.IdentityModel.Tokens;

namespace Repository.Repository
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<RequestView>> GetAllRequests()
        {
            var requests = await _context.Requests
                .Include(a => a.Apartment)
                .ToListAsync();
            IQueryable<RequestView> result = (from rq in _context.Requests
                                              join ap in _context.Apartments
                                              on rq.ApartmentId equals ap.ApartmentId
                                              join ow in _context.Owners
                                              on ap.OwnerId equals ow.OwnerId
                                              join pa in _context.Packages
                                              on rq.PackageID equals pa.PackageId
                                              join ao in _context.AddOns.DefaultIfEmpty()
                                              on rq.RequestId equals ao.RequestId into t1
                                              from ao in t1.DefaultIfEmpty()
                                              group ao by new
                                              {
                                                  RequestId = rq.RequestId,
                                                  ApartmentId = ap.ApartmentId,
                                                  BookDateTime = (DateTime)rq.BookDateTime,
                                                  EndDateTime = (DateTime)rq.BookDateTime,
                                                  ReqStatus = rq.ReqStatus,
                                                  OwnerId = ow.OwnerId,
                                                  RequestDescription = rq.Description,
                                                  PackageRequestedId = (int)rq.PackageID,
                                                  PackageName = pa.Name,
                                                  owner = ow.Name,
                                                  ApartmentName = ap.ApartmentName
                                              } into reqGroup
                                              select new RequestView
                                              {
                                                  RequestId = reqGroup.Key.RequestId,
                                                  ApartmentId = reqGroup.Key.ApartmentId,
                                                  BookDateTime = (DateTime)reqGroup.Key.BookDateTime,
                                                  EndDateTime = (DateTime)reqGroup.Key.BookDateTime,
                                                  ReqStatus = reqGroup.Key.ReqStatus,
                                                  OwnerId = reqGroup.Key.OwnerId,
                                                  RequestDescription = reqGroup.Key.RequestDescription,
                                                  PackageRequestedId = (int)reqGroup.Key.PackageRequestedId,
                                                  NumberOfAddOns = reqGroup.Count(x => x.Request != null),
                                                  PackageName = reqGroup.Key.PackageName,
                                                  Owner = reqGroup.Key.owner,
                                                  ApartmentName = reqGroup.Key.ApartmentName
                                              }
                           );
            return await result.ToListAsync();
        }

        public async Task<Request> GetRequestById(int id)
        {
            return _context.Requests
                .Include(a => a.Apartment)
                .FirstOrDefault(r => r.RequestId == id);
        }

        public Task<List<Request>> GetStaffRequests()
        {
            throw new NotImplementedException();
        }

        //public async Task<List<Request>> GetStaffRequests()
        //{
        //    var result = await _context.Requests.Include(r => r.Apartment)
        //                                .Include(r => r.RequestDetails).ThenInclude(rds => rds.Package)
        //                                .Include(r => r.AddOns).ToListAsync();
        //    return result;
        //}
    }
}
