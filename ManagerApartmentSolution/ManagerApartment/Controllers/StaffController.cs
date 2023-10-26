using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request.StaffRequest;
using Services.Models.Request.TennantRequest;
using Services.Models.Response.StaffResponse;
using Services.Models.Response.TennantResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private StaffService _staffService;
        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseAccountStaff>>> GetStaffs()
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

        [HttpGet("{id}")]
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
        [HttpGet("staff-name/{name}")]
        public async Task<ActionResult<ResponseAccountStaff>> GetStaffByName(string name)
        {
            var staff = await _staffService.GetStaffByName(name);
            return staff == null ? NotFound() : Ok(staff);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseAccountStaff>> CreateStaff(RequestCreateStaff staff)
        {
            var createdStaff = await _staffService.CreateStaff(staff);
            return createdStaff == null ? NotFound() : Ok(createdStaff);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseAccountStaff>> UpdateStaff(int id, UpdateStaff updateStaff)
        {
            var updatedStaff = await _staffService.UpdateStaff(id, updateStaff);
            return updatedStaff == null ? NotFound() : Ok(updatedStaff);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStaff(int id)
        {
            var deletedStaff = _staffService.DeleteStaff(id);
            return deletedStaff == null ? NoContent() : Ok(deletedStaff);
        }

        [HttpGet("request-list")]
        public async Task<IActionResult> GetStaffRequestList()
        {
            try
            {
                return Ok(await _staffService.GetRequets());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}