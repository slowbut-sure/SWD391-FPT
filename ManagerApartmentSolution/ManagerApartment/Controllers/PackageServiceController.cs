using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.PackageResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
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

        [HttpGet("{packageServiceId}")]
        public async Task<ActionResult<ResponseOfPackageServiceDetail>> GetPackageServiceById(int packageServiceId)
        {
            try
            {
                var packageService = await _packageService.GetPackageServiceDetailById(packageServiceId);
                return Ok(packageService);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
