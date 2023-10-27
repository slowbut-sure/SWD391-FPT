using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.Response.Asset;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/asset-history")]
    [ApiController]
    public class AssetHistoryController : ControllerBase
    {
        private AssetHistoryService _assetHisService;
        public AssetHistoryController(AssetHistoryService assetHisService)
        {
            _assetHisService = assetHisService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfAssetHistory>>> GetAssetHistoris()
        {
            try
            {
                var assHistoris = await _assetHisService.GetAllAssetHistoris();
                return Ok(assHistoris);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOfAssetHistory>> GetAssetHistoryById(int id)
        {
            try
            {
                var assHistory = await _assetHisService.GetAssetHistoryById(id);
                return Ok(assHistory);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
