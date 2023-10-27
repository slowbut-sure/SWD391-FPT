using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Response.Response.Bill;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/bill")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private BillService _billService;
        public BillController(BillService billService)
        {
            _billService = billService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfBill>>> GetBills(int page = 1, int pageSize = 10, string sortOrder = "asc")
        {
            try
            {
                var bills = await _billService.GetAllBills(page, pageSize, sortOrder);
                return Ok(bills);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
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
