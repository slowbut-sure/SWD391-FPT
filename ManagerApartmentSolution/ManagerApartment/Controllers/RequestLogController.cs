using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.RequestRespponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestLogController : Controller
    {
        private RequestLogService _rqLogService;
        public RequestLogController(RequestLogService rqLogService)
        {
            _rqLogService = rqLogService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfRequestLog>>> GetRequestLogs()
        {
            try
            {
                var requests = await _rqLogService.GetAllRequestLogs();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{requestLogId}")]
        public async Task<ActionResult<ResponseOfRequestLog>> GetRequestLogById(int id)
        {
            try
            {
                var request = await _rqLogService.GetRequestLogById(id);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
