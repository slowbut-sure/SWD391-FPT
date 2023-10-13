using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.ApartmentResponse;
using Services.Models.Response.ContractResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private ContractService _contractService;
        public ContractController(ContractService contractService)
        {
            _contractService = contractService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfContract>>> GetContracts()
        {
            try
            {
                var contracts = await _contractService.GetAllContracts();
                return Ok(contracts);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ResponseOfContract>> GetContractById(int id)
        {
            try
            {
                var contract = await _contractService.GetContractById(id);
                return Ok(contract);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
