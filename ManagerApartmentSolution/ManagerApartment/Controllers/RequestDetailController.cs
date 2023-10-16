using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.PackageResponse;
using Services.Models.Response.RequestRespponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
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

        [HttpGet("{requestDetailId}")]
        public async Task<ActionResult<ResponseOfRequestDetail>> GetRequestDetailById(int requestDetailId)
        {
            try
            {
                var request = await _rqDetailService.GetRequestDetailById(requestDetailId);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
