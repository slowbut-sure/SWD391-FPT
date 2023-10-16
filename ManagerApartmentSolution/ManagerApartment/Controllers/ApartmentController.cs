using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.ApartmentResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private ApartmentService _apartmentService;
        public ApartmentController(ApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfApartment>>> GetApartments()
        {
            try
            {
                var apartments = await _apartmentService.GetAllApartments();
                return Ok(apartments);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{apartmentId}")]
        public async Task<ActionResult<ResponseOfApartment>> GetApartmentById(int apartmentId)
        {
            try
            {
                var apartment = await _apartmentService.GetApartmentById(apartmentId);
                return Ok(apartment);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
