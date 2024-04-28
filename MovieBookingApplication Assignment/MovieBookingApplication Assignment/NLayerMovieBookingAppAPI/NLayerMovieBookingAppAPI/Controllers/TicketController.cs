using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerMovieBookingAppBLL.Helper;
using NLayerMovieBookingAppBLL.IServices;
using NLayerMovieBookingAppBLL.Models;
using NLayerMovieBookingAppDomain.Common;
using System.Net;

namespace NLayerMovieBookingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly AuthHelper _helper;
        public TicketController(ITicketService ticketService, IHttpContextAccessor httpContextAccessor)
        {
            _ticketService = ticketService;
            _helper = new AuthHelper(httpContextAccessor);
        }

        [HttpPost("generateTicket")]
        [Authorize]
        public async Task<IActionResult> CreateTicket([FromBody] TicketModel ticketData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (ticketData == null || ticketData.SeatCount>10)
                {
                    return BadRequest();
                }
                var loggedInUserId = _helper.GetUserId();
                var response= await _ticketService.CreateTicket(ticketData, loggedInUserId);
                if(response.StatusCode == HttpStatusCode.Created)
                {
                    return StatusCode((int)HttpStatusCode.Created, response.Data);
                }
                return StatusCode((int)response.StatusCode, response.ValidationError.Description);
            }
            catch (ApiException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Internal ServerError Occured", ex.Exception });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Internal ServerError Occured", ex });
            }
        }

        [HttpGet("getAllUserTickets")]
        [Authorize]
        public async Task<IActionResult> GetAllUserTickets()
        {
            try
            {
                var loggedInUserId= _helper.GetUserId();
                if (loggedInUserId == null)
                {
                    return Unauthorized();
                }
                var allTickets = await _ticketService.GetAllUserTickets(loggedInUserId);
                if (allTickets.Data.Count == 0)
                {
                    return NotFound();
                }
                return Ok(allTickets.Data);
            }
            catch (ApiException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Internal ServerError Occured", ex.Exception });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Internal ServerError Occured", ex });
            }
        }
    }
}
