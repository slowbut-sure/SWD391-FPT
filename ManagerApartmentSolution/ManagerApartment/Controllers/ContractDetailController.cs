using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.ApartmentResponse;
using Services.Models.Response.ContractResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContractDetailController : ControllerBase
    {
        private ContractDetailService _contractDetail;
        public ContractDetailController(ContractDetailService contractDetail)
        {
            _contractDetail = contractDetail;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseOfContractDetail>>> GetContractDetails()
        {
            try
            {
                var contractDetail = await _contractDetail.GetAllContractDetails();
                return Ok(contractDetail);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{contractDetailId}")]
        public async Task<ActionResult<ResponseOfContractDetail>> GetContractDeatailById(int id)
        {
            try
            {
                var contractDetail = await _contractDetail.GetContractDetailById(id);
                return Ok(contractDetail);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
