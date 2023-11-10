using ManagerApartment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request.RequestRequest;
using Services.Models.Request.TennantRequest;
using Services.Models.Response;
using Services.Models.Response.Response.PackageResponse;
using Services.Models.Response.Response.RequestRespponse;
using Services.Models.Response.Response.TennantResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/requests")]
    [ApiController]
    public class RequestController : Controller
    {
        private RequestService _requestService;
        public RequestController(RequestService requestService)
        {
            _requestService = requestService;
        }
        [HttpGet]
        public async Task<ActionResult<DataResponse<List<ResponseOfRequest>>>> GetRequests(int page = 1, int pageSize = 10, string sortOrder = "asc")
        {
            try
            {
                var requests = await _requestService.GetRequestWithCurrentStatus(page, pageSize, sortOrder);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<ResponseOfRequest>> GetRequestById(int id)
        //{
        //    try
        //    {
        //        var request = await _requestService.GetRequestById(id);
        //        return Ok(request);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}

        //[HttpGet("{staffid")]
        //public async Task<ActionResult<List<ResponseOfRequest>>> GetPendingAndProcessRequestByStaffId(int staffid, int page = 1, int pageSize = 5, string sortOrder = "asc")
        //{
        //    try
        //    {
        //        var requests = await _requestService.GetPendingAndProcessRequestsByStaffId(staffid,page, pageSize, sortOrder);
        //        return Ok(requests);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRequest(int id)
        {
            var deletedRequest = _requestService.DeleteRequest(id);
            return deletedRequest == null ? NoContent() : Ok(deletedRequest);
        }

        [HttpGet("apartments/{apartmentId}")]
        public async Task<ActionResult<DataResponse<List<ResponseOfRequest>>>> GetRequestsByApartment(int apartmentId)
        {
            var response = await _requestService.GetRequestsByApartment(apartmentId);
            return response == null ? NoContent() : Ok(response);
        }


        [HttpGet("staffs/{staffId}")]
        public async Task<IActionResult> GetAllRequestsByStaffId(int staffId, int page = 1, int pageSize = 10, string sortOrder = "asc")
        {
            var response = await _requestService.GetAllRequestsByStaffId(staffId, page, pageSize, sortOrder);
            return response == null ? NoContent() : Ok(response);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetAllRequestsByStaffId(string status, int page = 1, int pageSize = 10, string sortOrder = "asc")
        {
            var response = await _requestService.GetAllRequestsByStatus(status, page, pageSize, sortOrder);
            return response == null ? NoContent() : Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<DataResponse<ResponseOfRequest>>> CreateRequest([FromBody]RequestCreateRequest request)
        {
            var createdRequest = await _requestService.CreateRequest(request);
            return createdRequest.Data == null ? UnprocessableEntity(createdRequest) : Ok(createdRequest);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponse<ResponseOfRequestDetail>>> GetRequestDetail(int id)
        {
            var result = await _requestService.GetRequestDetail(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("owners/{ownerId}")]
        public async Task<IActionResult> GetRequestsByOwnerId(int ownerId)
        {
            var result = await _requestService.GetRequestByOwnerId(ownerId);
            return result.Data == null ? NotFound() : Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<DataResponse<ResponseOfRequestLog>>> UpdateRequest([FromBody] RequestRequestLog log)
        {
            var updatedRequest = await _requestService.UpdateRequest(log);
            return updatedRequest == null ? NotFound() : Ok(updatedRequest);
        }


        [HttpGet("apartment-request-by-month")]
        public async Task<ActionResult<List<dynamic>>> GetApartmentRequestCountByMonth()
        {
            try
            {
                var apartmentRequestCounts = await _requestService.GetApartmentRequestCountByMonth();
                return Ok(apartmentRequestCounts);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("most-apartments-requested-by-month")]
        public async Task<ActionResult<List<dynamic>>> GetMostRequestedApartmentsByMonth()
        {
            try
            {
                var result = await _requestService.GetMostRequestedApartmentsByMonth();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
