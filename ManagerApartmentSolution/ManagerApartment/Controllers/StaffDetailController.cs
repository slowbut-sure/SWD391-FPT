using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.RequestRespponse;
using Services.Models.Response.StaffResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
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

        [HttpGet("{staffDetailId}")]
        public async Task<ActionResult<ResponseOfStaffDetail>> GetStaffDetailById(int staffDetailId)
        {
            try
            {
                var staff = await _staffDetailService.GetStaffDetailById(staffDetailId);
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
