using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.PackageResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/package-service")]
    [ApiController]
    public class PackageServiceController : Controller
    {
        private PackageServiceDetailService _packageService;
        public PackageServiceController(PackageServiceDetailService packageService)
        {
            _packageService = packageService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfPackageServiceDetail>>> GetPackageServices()
        {
            try
            {
                var packageServices = await _packageService.GetAllPackageServiceDetails();
                return Ok(packageServices);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOfPackageServiceDetail>> GetPackageServiceById(int id)
        {
            try
            {
                var packageService = await _packageService.GetPackageServiceDetailById(id);
                return Ok(packageService);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
