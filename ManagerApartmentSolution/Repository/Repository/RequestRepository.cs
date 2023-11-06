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
using Domain.Enums.Status;

namespace Repository.Repository
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(ManagerApartmentContext context) : base(context) { }

        public async Task<List<RequestView>> GetAllRequests()
        {
            IQueryable<RequestView> result = (from rq in _context.Requests
                                              where rq.ReqStatus != 1
                                              join ap in _context.Apartments
                                              on rq.ApartmentId equals ap.ApartmentId
                                              join ow in _context.Owners
                                              on ap.OwnerId equals ow.OwnerId
                                              join pa in _context.Packages
                                              on rq.PackageId equals pa.PackageId
                                              join ao in _context.AddOns
                                              on rq.RequestId equals ao.RequestId into t2
                                              from ao in t2.DefaultIfEmpty()
                                              group ao by new
                                              {
                                                  RequestId = rq.RequestId,
                                                  ApartmentId = ap.ApartmentId,
                                                  BookDateTime = (DateTime)rq.BookDateTime,
                                                  EndDateTime = (DateTime)rq.EndDate,
                                                  ReqStatus = rq.ReqStatus,
                                                  OwnerId = ow.OwnerId,
                                                  RequestDescription = rq.Description,
                                                  PackageRequestedId = (int)rq.PackageId,
                                                  PackageName = pa.Name,
                                                  owner = ow.Name,
                                                  ApartmentName = ap.ApartmentName,
                                                  PackagePrice = pa.Price,
                                              } into reqGroup
                                              select new RequestView
                                              {
                                                  RequestId = reqGroup.Key.RequestId,
                                                  ApartmentId = reqGroup.Key.ApartmentId,
                                                  BookDateTime = (DateTime)reqGroup.Key.BookDateTime,
                                                  EndDateTime = (DateTime)reqGroup.Key.EndDateTime,
                                                  ReqStatus = RequestEnum.PENDING.ToString()  /* reqGroup.Key.ReqStatus */,
                                                  OwnerId = reqGroup.Key.OwnerId,
                                                  RequestDescription = reqGroup.Key.RequestDescription,
                                                  PackageRequestedId = (int)reqGroup.Key.PackageRequestedId,
                                                  NumberOfAddOns = reqGroup.Count(x => x != null),
                                                  PackageName = reqGroup.Key.PackageName,
                                                  Owner = reqGroup.Key.owner,
                                                  ApartmentName = reqGroup.Key.ApartmentName,
                                                  PackagePrice = reqGroup.Key.PackagePrice
                                              }
                           );
            return await result.ToListAsync();
        }

        public async Task<List<RequestView>> GetPendingAndProcessingRequestByStaffId(int staffId)
        {
            IQueryable<RequestView> result = (from rq in _context.Requests
                                              where rq.ReqStatus != 1
                                              join ap in _context.Apartments
                                              on rq.ApartmentId equals ap.ApartmentId
                                              join ow in _context.Owners
                                              on ap.OwnerId equals ow.OwnerId
                                              join pa in _context.Packages
                                              on rq.PackageId equals pa.PackageId
                                              join rl in _context.RequestLogs
                                              on rq.RequestId equals rl.RequestId
                                              join ao in _context.AddOns
                                              on rq.RequestId equals ao.RequestId into t2
                                              where rl.StaffId == staffId && (rl.Status.Equals(RequestEnum.PENDING.ToString()) || rl.Status.Equals(RequestEnum.PROCESSING.ToString()))
                                              from ao in t2.DefaultIfEmpty()
                                              group ao by new
                                              {
                                                  RequestId = rq.RequestId,
                                                  ApartmentId = ap.ApartmentId,
                                                  BookDateTime = (DateTime)rq.BookDateTime,
                                                  EndDateTime = (DateTime)rq.BookDateTime,
                                                  ReqStatus = rq.ReqStatus,
                                                  OwnerId = ow.OwnerId,
                                                  RequestDescription = rq.Description,
                                                  PackageRequestedId = (int)rq.PackageId,
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
                                                  //ReqStatus = Enum.Parse(typeof(RequestEnum), reqGroup.Key.ReqStatus).ToString()  /* reqGroup.Key.ReqStatus */,
                                                  OwnerId = reqGroup.Key.OwnerId,
                                                  RequestDescription = reqGroup.Key.RequestDescription,
                                                  PackageRequestedId = (int)reqGroup.Key.PackageRequestedId,
                                                  NumberOfAddOns = reqGroup.Count(x => x != null),
                                                  PackageName = reqGroup.Key.PackageName,
                                                  Owner = reqGroup.Key.owner,
                                                  ApartmentName = reqGroup.Key.ApartmentName
                                              }
                           );
            return await result.ToListAsync();
        }

        public async Task<RequestView?> GetRequestById(int id)
        {
            IQueryable<RequestView> requestView = (from rq in _context.Requests
                                                    where rq.ReqStatus != 1 && rq.RequestId == id
                                                    join ap in _context.Apartments
                                                    on rq.ApartmentId equals ap.ApartmentId
                                                    join bu in _context.Buildings
                                                    on ap.BuildingId equals bu.BuildingId
                                                    join ow in _context.Owners
                                                    on ap.OwnerId equals ow.OwnerId
                                                    join pa in _context.Packages
                                                    on rq.PackageId equals pa.PackageId
                                                    select new RequestView
                                                    {
                                                        RequestId = rq.RequestId,
                                                        ApartmentId = ap.ApartmentId,
                                                        BookDateTime = (DateTime)rq.BookDateTime,
                                                        EndDateTime = (DateTime)rq.EndDate,
                                                        ReqStatus = /* rq.ReqStatus */  RequestEnum.PENDING.ToString(),
                                                        OwnerId = ow.OwnerId,
                                                        RequestDescription = rq.Description,
                                                        PackageRequestedId = (int)rq.PackageId,
                                                        PackageName = pa.Name,
                                                        Owner = ow.Name,
                                                        ApartmentAddress = bu.Address,
                                                        ApartmentName = ap.ApartmentName,
                                                        PackagePrice = pa.Price
                                                    }
                           );

            List<RequestView> list = await requestView.ToListAsync();
            return  await Task.FromResult(list[0]);
        }

        public async Task<List<Request>> GetRequestsByApartmentId(int apartmentId)
        {
            return await _context.Requests
                            .Where(rq => rq.ApartmentId == apartmentId)
                            .Include(rq => rq.Apartment).ThenInclude(a => a.Owner) 
                            .Include(rq => rq.Package)
                            .Include(rq => rq.AddOns)
                            .Include(rq => rq.RequestLogs)
                            .Include (rq => rq.Bills)
                            .ToListAsync();
        }

        public async Task<List<RequestView>> GetRequestsByStaffId(int staffId)
        {
            IQueryable<RequestView> result = (from rq in _context.Requests
                                              where rq.ReqStatus != 1
                                              join ap in _context.Apartments
                                              on rq.ApartmentId equals ap.ApartmentId
                                              join ow in _context.Owners
                                              on ap.OwnerId equals ow.OwnerId
                                              join pa in _context.Packages
                                              on rq.PackageId equals pa.PackageId
                                              join rl in _context.RequestLogs
                                              on rq.RequestId equals rl.RequestId
                                              join ao in _context.AddOns
                                              on rq.RequestId equals ao.RequestId into t2
                                              where rl.StaffId == staffId
                                              from ao in t2.DefaultIfEmpty()
                                              group ao by new
                                              {
                                                  RequestId = rq.RequestId,
                                                  ApartmentId = ap.ApartmentId,
                                                  BookDateTime = (DateTime)rq.BookDateTime,
                                                  EndDateTime = (DateTime)rq.BookDateTime,
                                                  ReqStatus = rq.ReqStatus,
                                                  OwnerId = ow.OwnerId,
                                                  RequestDescription = rq.Description,
                                                  PackageRequestedId = (int)rq.PackageId,
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
                                                  //ReqStatus = Enum.Parse(typeof(RequestEnum), reqGroup.Key.ReqStatus).ToString()  /* reqGroup.Key.ReqStatus */,
                                                  OwnerId = reqGroup.Key.OwnerId,
                                                  RequestDescription = reqGroup.Key.RequestDescription,
                                                  PackageRequestedId = (int)reqGroup.Key.PackageRequestedId,
                                                  NumberOfAddOns = reqGroup.Count(x => x != null),
                                                  PackageName = reqGroup.Key.PackageName,
                                                  Owner = reqGroup.Key.owner,
                                                  ApartmentName = reqGroup.Key.ApartmentName
                                              }
                           );
            return await result.ToListAsync();
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
