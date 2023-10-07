using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.StaffResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private StaffService _staffService;
        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseAccountStaff>>> GetAllStaffs()
        {
            try
            {
                var staff = await _staffService.GetAllStaffs();
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ResponseAccountStaff>> GetStaffById(int id)
        {
            try
            {
                var staff = await _staffService.GetStaffById(id);
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

}