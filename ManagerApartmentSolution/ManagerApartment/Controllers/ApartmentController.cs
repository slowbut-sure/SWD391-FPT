using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.ApartmentResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    //[Authorize]
    [Route("api/apartment")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private ApartmentService _apartmentService;
        public ApartmentController(ApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfApartment>>> GetApartments(int page = 1, int pageSize = 10, string sortOrder = "asc")
        {
            try
            {
                var apartments = await _apartmentService.GetAllApartments(page, pageSize, sortOrder);
                return Ok(apartments);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOfApartment>> GetApartmentById(int id)
        {
            try
            {
                var apartment = await _apartmentService.GetApartmentById(id);
                return Ok(apartment);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
