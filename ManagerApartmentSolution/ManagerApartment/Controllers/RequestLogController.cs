using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request.RequestDetailRequest;
using Services.Models.Response.RequestRespponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/request-log")]
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

        [HttpGet("{id}")]
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
        [HttpPost]
        public async Task<ActionResult<ResponseOfRequestLog>> CreateRequestLog(RqLogCreateRequest rqLog)
        {
            var createdRqLog = await _rqLogService.CreateRequestLog(rqLog);
            return createdRqLog == null ? NotFound() : Ok(createdRqLog);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseOfRequestLog>> UpdateRequestLog(int id, UpdateRequestLog updateRqLog)
        {
            var updatedRqLog = await _rqLogService.UpdateRequestLog(id, updateRqLog);
            return updatedRqLog == null ? NotFound() : Ok(updatedRqLog);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRequestLog(int id)
        {
            var deletedRqLog = _rqLogService.DeleteRequestLog(id);
            return deletedRqLog == null ? NoContent() : Ok(deletedRqLog);
        }
    }
}
