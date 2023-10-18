using ManagerApartment.Models;
using Services.Models.Response.PackageResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface PackageService
    {
        Task<List<ResponseOfPackage>> GetAllPackages(int page, int pageSize, string sortOrder);
        Task<ResponseOfPackage> GetPackageById(int id);
    }
}
