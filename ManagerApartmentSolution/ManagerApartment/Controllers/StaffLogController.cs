using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.StaffResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/staff-log")]
    [ApiController]
    public class StaffLogController : Controller
    {
        private StaffLogService _staffLogService;
        public StaffLogController(StaffLogService staffLogService)
        {
            _staffLogService = staffLogService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfStaffLog>>> GetStaffLogs()
        {
            try
            {
                var staff = await _staffLogService.GetAllStaffLogs();
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOfStaffLog>> GetStaffLogById(int id)
        {
            try
            {
                var staff = await _staffLogService.GetStaffLogById(id);
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
