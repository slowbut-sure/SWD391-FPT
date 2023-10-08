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
        Task<List<ResponseOfPackage>> GetAllPackages();
        Task<ResponseOfPackage> GetPackageById(int id);
    }
}
