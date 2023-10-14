using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.Bill;
using Services.Models.Response.TennantResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private BillService _billService;
        public BillController(BillService billService)
        {
            _billService = billService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfBill>>> GetBills()
        {
            try
            {
                var bills = await _billService.GetAllBills();
                return Ok(bills);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{billId}")]
        public async Task<ActionResult<ResponseOfBill>> GetBillById(int id)
        {
            try
            {
                var bill = await _billService.GetBillById(id);
                return Ok(bill);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
