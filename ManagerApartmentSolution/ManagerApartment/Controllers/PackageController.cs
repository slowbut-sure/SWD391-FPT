using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response;
using Services.Models.Response.Response.PackageResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/package")]
    [ApiController]
    public class PackageController : Controller
    {
        private PackageService _packageService;
        public PackageController(PackageService packageService)
        {
            _packageService = packageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPackages(int page = 1)
        {
            try
            {
                int pageSize = 10;
                string sortOrder = "asc";
                var packages = await _packageService.GetAllPackages(page, pageSize, sortOrder);
                return Ok(packages);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOfPackage>> GetPackageById(int id)
        {
            try
            {
                var package = await _packageService.GetPackageById(id);
                return Ok(package);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
