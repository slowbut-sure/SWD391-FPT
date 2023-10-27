using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.Response.BuildingResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/building")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private BuildingService _buildingService;
        public BuildingController(BuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfBuilding>>> GetBuildings()
        {
            try
            {
                var buildings = await _buildingService.GetAllBuildings();
                return Ok(buildings);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOfBuilding>> GetBuildingById(int id)
        {
            try
            {
                var building = await _buildingService.GetBuildingById(id);
                return Ok(building);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
