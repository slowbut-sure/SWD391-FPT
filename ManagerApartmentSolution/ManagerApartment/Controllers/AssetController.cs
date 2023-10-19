using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request.AssetRequest;
using Services.Models.Request.TennantRequest;
using Services.Models.Response.Asset;
using Services.Models.Response.ResponseAssetHistoryByAssetId;
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
        public async Task<ActionResult<ResponseOfAsset>> GetAssetById(int assetId)
        {
            try
            {
                var asset = await _assetService.GetAssetById(assetId);
                return Ok(asset);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("AssetHistory/{assetId}")]
        public async Task<ActionResult<ResponseAssetHistory>> GetAssetHistoryByAssetId(int assetId)
        {
            try
            {
                var asset = await _assetService.GetAssetHistoryByAssetId(assetId);
                return Ok(asset);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{assetId}")]
        public async Task<ActionResult<ResponseOfAsset>> UpdateAsset(int assetId, UpdateAsset updateAsset)
        {
            var updatedAsset = await _assetService.UpdateAsset(assetId, updateAsset);
            return updatedAsset == null ? NotFound() : Ok(updatedAsset);
        }

        [HttpDelete("{assetId}")]
        public async Task<ActionResult> DeleteAsset(int assetId)
        {
            var deletedAsset = _assetService.DeleteAsset(assetId);
            return deletedAsset == null ? NoContent() : Ok(deletedAsset);
        }
    }
}
