using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.AddOnResponse;
using Services.Models.Response.StaffResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
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
