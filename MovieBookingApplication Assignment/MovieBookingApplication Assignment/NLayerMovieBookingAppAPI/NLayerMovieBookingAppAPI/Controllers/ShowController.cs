using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerMovieBookingAppBLL.IServices;
using NLayerMovieBookingAppBLL.Models;
using NLayerMovieBookingAppBLL.Services;
using NLayerMovieBookingAppDomain.Common;
using System.Net;

namespace NLayerMovieBookingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;
        public ShowController(IShowService showService)
        {
            _showService = showService;
        }

        [HttpPost("addShowForMovie")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddShowForMovie([FromBody] AddMovieShowModel showData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (showData == null)
                {
                    return BadRequest();
                }
                var response = await _showService.AddShowForMovie(showData);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return StatusCode((int)HttpStatusCode.Created, new { message = response.Message });
                }
                return StatusCode((int)response.StatusCode, new { message = response.Message });
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

        [HttpGet("getAllAvailableShows")]
        public async Task<IActionResult> GetAllAvailableShows()
        {
            try
            {
                var response= await _showService.GetAllAvailableMovieShows();
                if (response.Data.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(response.Data);
            }
            catch(ApiException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Internal ServerError Occured", ex.Exception });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Internal ServerError Occured", ex });
            }

        }

        [HttpGet("getAllFilteredAvailableShows/{date}")]
        public async Task<IActionResult> GetAllAvailableShowsForDate([FromRoute] DateTime date)
        {
            try
            {
                var response = await _showService.GetAllFilteredAvailableMovieShows(date);
                if (response.Data.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(response.Data);
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
