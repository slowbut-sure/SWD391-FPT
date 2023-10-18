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

        [HttpGet("{assetHistoryId}")]
        public async Task<ActionResult<ResponseOfAssetHistory>> GetAssetHistoryById(int assetHistoryId)
        {
            try
            {
                var assHistory = await _assetHisService.GetAssetHistoryById(assetHistoryId);
                return Ok(assHistory);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
