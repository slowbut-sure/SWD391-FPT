using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.Asset;
using Services.Models.Response.TennantResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private AssetService _assetService;
        public AssetController(AssetService assetService)
        {
            _assetService = assetService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfAsset>>> GetAssets()
        {
            try
            {
                var assets = await _assetService.GetAllAssets();
                return Ok(assets);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{assetId}")]
        public async Task<ActionResult<ResponseOfAsset>> GetAssetById(int id)
        {
            try
            {
                var asset = await _assetService.GetAssetById(id);
                return Ok(asset);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
