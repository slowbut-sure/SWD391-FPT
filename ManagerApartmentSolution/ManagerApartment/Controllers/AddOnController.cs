using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.Response.AddOnResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/add-on")]
    [ApiController]
    public class AddOnController : ControllerBase
    {
        private AddOnService _addOnService;
        public AddOnController(AddOnService addOnService)
        {
            _addOnService = addOnService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfAddOn>>> GetAddOns()
        {
            try
            {
                var addOns = await _addOnService.GetAllAddOnss();
                return Ok(addOns);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOfAddOn>> GetAddOnById(int id)
        {
            try
            {
                var addOn = await _addOnService.GetAddOnById(id);
                return Ok(addOn);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
