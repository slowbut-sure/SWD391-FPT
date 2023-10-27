using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.Response.RequestRespponse;
using Services.Models.Response.Response.StaffResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/staff-detail")]
    [ApiController]
    public class StaffDetailController : Controller
    {
        private StaffDetailService _staffDetailService;
        public StaffDetailController(StaffDetailService staffDetailService)
        {
            _staffDetailService = staffDetailService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfStaffDetail>>> GetStaffDetails()
        {
            try
            {
                var staff = await _staffDetailService.GetAllStaffDetails();
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOfStaffDetail>> GetStaffDetailById(int id)
        {
            try
            {
                var staff = await _staffDetailService.GetStaffDetailById(id);
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
