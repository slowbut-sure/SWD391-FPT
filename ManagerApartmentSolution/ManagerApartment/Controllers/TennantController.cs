using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request.ServiceRequest;
using Services.Models.Request.TennantRequest;
using Services.Models.Response;
using Services.Models.Response.Response;
using Services.Models.Response.Response.ServiceResponse;
using Services.Models.Response.Response.StaffResponse;
using Services.Models.Response.Response.TennantResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/tennant")]
    [ApiController]
    public class TennantController : ControllerBase
    {
        private TennantService _tennantService;
        public TennantController(TennantService tennantService)
        {
            _tennantService = tennantService;
        }

        [HttpGet]
        public async Task<ActionResult<DataResponse<List<ResponseOfTennant>>>> GetTennants()
        {
            try
            {
                var tennant = await _tennantService.GetAllTennants();
                return Ok(tennant);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataResponse<ResponseOfTennant>>> GetTennantById(int id)
        {
            try
            {
                var staff = await _tennantService.GetTennantById(id);
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<DataResponse<ResponseOfTennant>>> CreateTennant(RequestCreateTennant tennant)
        {
            var createdTennant = await _tennantService.CreateTennant(tennant);
            return createdTennant == null ? NotFound() : Ok(createdTennant);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<DataResponse<ResponseOfTennant>>> UpdateTennant(int id, UpdateTennant updateTennant)
        {
            var updatedTennant = await _tennantService.UpdateTennant(id, updateTennant);
            return updatedTennant == null ? NotFound() : Ok(updatedTennant);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTennant(int id)
        {
            var deletedTennant = _tennantService.DeleteTennant(id);
            return deletedTennant == null ? NoContent() : Ok(deletedTennant);
        }
    }
}
