using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.ContractResponse;
using Services.Models.Response.OwnerResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private OwnerService _ownerService;
        public OwnerController(OwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfOwner>>> GetOwners()
        {
            try
            {
                var owners = await _ownerService.GetAllOwners();
                return Ok(owners);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{ownerId}")]
        public async Task<ActionResult<ResponseOfOwner>> GetOwnerById(int id)
        {
            try
            {
                var owner = await _ownerService.GetOwnerById(id);
                return Ok(owner);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
