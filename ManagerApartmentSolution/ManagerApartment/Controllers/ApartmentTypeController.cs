using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.Response.ApartmentResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/apartment-type")]
    [ApiController]
    public class ApartmentTypeController : ControllerBase
    {
        private readonly ApartmentTypeService _service;
        public ApartmentTypeController(ApartmentTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseOfApartmentType>>> GetApartmentTypes()
        {
            try
            {
                var apTypes = await _service.GetAllApartmentTypes();
                return Ok(apTypes);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOfApartmentType>> GetApartmentTypeById(int id)
        {
            try
            {
                var apType = await _service.GetApartmentTypeById(id);
                return Ok(apType);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
