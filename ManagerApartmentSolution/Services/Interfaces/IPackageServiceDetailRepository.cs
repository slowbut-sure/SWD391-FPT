using ManagerApartment.Models;
using Services.Interfaces.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPackageServiceDetailRepository : IGenericRepository<PackageServiceDetail>
    {
        Task<List<PackageServiceDetail>> GetAllPackageServiceDetails();
        Task<PackageServiceDetail> GetPackageServiceDetailById(int id);
    }
}
