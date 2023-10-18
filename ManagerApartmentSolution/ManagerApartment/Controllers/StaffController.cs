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
    [Route("api/[controller]")]
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

        [HttpGet("{staffId}")]
        public async Task<ActionResult<ResponseAccountStaff>> GetStaffById(int staffId)
        {
            try
            {
                var staff = await _staffService.GetStaffById(staffId);
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("StaffName/{name}")]
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
        [HttpPut("{staffId}")]
        public async Task<ActionResult<ResponseAccountStaff>> UpdateStaff(int staffId, UpdateStaff updateStaff)
        {
            var updatedStaff = await _staffService.UpdateStaff(staffId, updateStaff);
            return updateStaff == null ? NotFound() : Ok(updateStaff);
        }

        [HttpDelete("{staffId}")]
        public async Task<ActionResult> DeleteStaff(int staffId)
        {
            var deletedStaff = _staffService.DeleteStaff(staffId);
            return deletedStaff == null ? NoContent() : Ok(deletedStaff);
        }
    }

}