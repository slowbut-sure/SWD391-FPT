using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request.ServiceRequest;
using Services.Models.Response.Response.ServiceResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private ServiceService _serviceService;
        public ServiceController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfService>>> GetServices()
        {
            try
            {
                var services = await _serviceService.GetAllServices();
                return Ok(services);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("packageID/{packageId}")]
        public async Task<ActionResult<ResponseOfService>> GetServiceByPackageId (int packageId)
        {
            try
            {
                var res = await _serviceService.GetServicesByPackageId(packageId);
                return Ok(res);
            }catch(Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

        

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOfService>> GetServiceById(int id)
        {
            try
            {
                var service = await _serviceService.GetServiceById(id);
                return Ok(service);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseOfService>> CreateService(RequestCreateService service)
        {
            var createdService = await _serviceService.CreateService(service);
            return createdService == null ? NotFound() : Ok(createdService);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseOfService>> UpdateService(int id, UpdateService updateService)
        {
            var updatedService = await _serviceService.UpdateService(id, updateService);
            return updatedService == null ? NotFound() : Ok(updateService);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteService(int id)
        {
            var deletedService = _serviceService.DeleteService(id);
            return deletedService == null ? NoContent() : Ok(deletedService);
        }
    }
}
