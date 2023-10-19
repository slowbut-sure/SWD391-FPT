using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.PackageResponse;
using Services.Models.Response.RequestRespponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/request-detail")]
    [ApiController]
    public class RequestDetailController : Controller
    {
        private RequestDetailService _rqDetailService;
        public RequestDetailController(RequestDetailService rqDetailService)
        {
            _rqDetailService = rqDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseOfRequestDetail>>> GetRequestDetails()
        {
            try
            {
                var requests = await _rqDetailService.GetAllRequestDetails();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOfRequestDetail>> GetRequestDetailById(int id)
        {
            try
            {
                var request = await _rqDetailService.GetRequestDetailById(id);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
