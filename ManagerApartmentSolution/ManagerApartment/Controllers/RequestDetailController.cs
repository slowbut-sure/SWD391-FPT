using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Servicesss;
using Services.Models.Response.Response.RequestRespponse;

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
        public async Task<ActionResult<ResponseOfRequestDetail>> GetRequestDetailByRequestId(int id)
        {
            try
            {
                var request = await _rqDetailService.GetRequestDetailByRequestId(id);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
