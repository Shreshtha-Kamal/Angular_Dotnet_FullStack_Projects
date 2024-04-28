using BillManagementBLL.IServices;
using BillManagementBLL.Models;
using BillManagementBLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NLayerBillManagementArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost("createBill")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateBill(BillModel bill)
        {
            if (bill == null|| !ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _billService.AddBill(bill);
            if (response == null)
            {
                return BadRequest(new
                {
                    message= "Bill Date Clash Occured"
                });
            }
            return Ok(new
            {
                response
            });
        }

        [HttpGet("getUserSixMonthsBills/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserSixMonthBills([FromRoute] string id)
        {
            var sixMonthBills = await _billService.GetUserSixMonthBills(id);
            if (sixMonthBills == null)
            {
                return NotFound(new
                {
                    Message= "No Bills Created Till Now"
                });
            }
            return Ok(sixMonthBills);
        }

        [HttpPost("payBill/{id}")]
        [Authorize(Roles ="User")]
        public async Task<IActionResult> PayBill([FromRoute]string id)
        {
            var response = await _billService.PayBill(id);
            if(response == null)
            {
                return NotFound(new
                {
                    Message= "Bill with this Id doesnot exist"
                });
            }
            return Ok(new
            {
                response
            });
        }
    }
}
