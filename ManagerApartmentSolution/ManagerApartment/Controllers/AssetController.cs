using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request.AssetRequest;
using Services.Models.Response.Response.Asset;
using Services.Models.Response.Response.ResponseAssetHistoryByAssetId;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/asset")]
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

        [HttpGet("{id}")]
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
        [HttpGet("apartment/{id}")]
        public async Task<ActionResult<ResponseOfAsset>> GetAssetByApartmentId(int id)
        {
            try
            {
                var asset = await _assetService.GetAssetByApartmentId(id);
                return Ok(asset);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("asset-history/{id}")]
        public async Task<ActionResult<ResponseAssetHistory>> GetAssetHistoryByAssetId(int id)
        {
            try
            {
                var asset = await _assetService.GetAssetHistoryByAssetId(id);
                return Ok(asset);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseOfAsset>> UpdateAsset(int id, UpdateAsset updateAsset)
        {
            var updatedAsset = await _assetService.UpdateAsset(id, updateAsset);
            return updatedAsset == null ? NotFound() : Ok(updatedAsset);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsset(int id)
        {
            var deletedAsset = _assetService.DeleteAsset(id);
            return deletedAsset == null ? NoContent() : Ok(deletedAsset);
        }
    }
}
