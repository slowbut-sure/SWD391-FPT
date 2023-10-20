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
    public class PackageServiceDetailRepository : GenericRepository<PackageServiceDetail>, IPackageServiceDetailRepository
    {
        public PackageServiceDetailRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<PackageServiceDetail>> GetAllPackageServiceDetails()
        {
            var packageServiceDetails = await _context.PackageServiceDetails
                .ToListAsync();
            return packageServiceDetails;
        }

        public async Task<PackageServiceDetail> GetPackageServiceDetailById(int id)
        {
            return  _context.PackageServiceDetails.FirstOrDefault(r => r.PackSerDetailId == id);
        }
    }
}
