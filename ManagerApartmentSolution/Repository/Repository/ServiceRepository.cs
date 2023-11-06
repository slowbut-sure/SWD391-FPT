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
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<Service>> GetAllServices()
        {
            var services = await _context.Services
                .ToListAsync();
            return services;
        }

        public async Task<Service> GetServiceById(int id)
        {
            return _context.Services.FirstOrDefault(s => s.ServiceId == id);
        }

        public async Task<List<Service>> GetAddOnServiceByRequestId(int requestId)
        {
            IQueryable<Service> addOnServicesList = from rq in _context.Requests
                                                    where rq.RequestId == requestId
                                                    join ao in _context.AddOns
                                                    on rq.RequestId equals ao.RequestId
                                                    join ser in _context.Services
                                                    on ao.ServiceId equals ser.ServiceId
                                                    select new Service
                                                    {
                                                        ServiceId = ser.ServiceId,
                                                        Name = ser.Name,
                                                        Code = ser.Code,
                                                        ServiceStatus = ser.ServiceStatus,
                                                        Price = ser.Price,
                                                        Unit = ser.Unit,
                                                        PackageServiceDetails = ser.PackageServiceDetails,
                                                        StaffDetails = ser.StaffDetails
                                                    };
            return await addOnServicesList.ToListAsync();
        }

        public async Task<List<Service>> GetServiceByPackageId(int packageId)
        {
            IQueryable<Service> list = (from pa in _context.Packages
                                        where pa.PackageId == packageId
                                        join psd in _context.PackageServiceDetails
                                       on pa.PackageId equals psd.PackageId
                                        join ser in _context.Services
                                        on psd.ServiceId equals ser.ServiceId
                                        select new Service
                                        {
                                            ServiceId = ser.ServiceId,
                                            Code = ser.Code,
                                            Name = ser.Name,
                                            Price = ser.Price,
                                            Unit = ser.Unit,
                                            ServiceStatus = ser.ServiceStatus
                                        });
            return await list.ToListAsync();
        }
    }
}
