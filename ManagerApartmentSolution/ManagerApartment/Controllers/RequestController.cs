using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.PackageResponse;
using Services.Models.Response.RequestRespponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : Controller
    {
        private RequestService _requestService;
        public RequestController(RequestService requestService)
        {
            _requestService = requestService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfRequest>>> GetRequests(int page = 1, int pageSize = 10, string sortOrder = "asc")
        {
            try
            {
                var requests = await _requestService.GetAllRequests(page, pageSize, sortOrder);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{requestId}")]
        public async Task<ActionResult<ResponseOfRequest>> GetRequestById(int requestId)
        {
            try
            {
                var request = await _requestService.GetRequestById(requestId);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
