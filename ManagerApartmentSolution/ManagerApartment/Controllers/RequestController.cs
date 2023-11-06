using ManagerApartment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response;
using Services.Models.Response.Response.PackageResponse;
using Services.Models.Response.Response.RequestRespponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    //[Authorize]
    [Route("api/request")]
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

    }
}
