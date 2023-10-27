using ManagerApartment.Models;
using Services.Models.Response.Response.PackageResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface PackageServiceDetailService
    {
        Task<List<ResponseOfPackageServiceDetail>> GetAllPackageServiceDetails();
        Task<ResponseOfPackageServiceDetail> GetPackageServiceDetailById(int id);
    }
}
