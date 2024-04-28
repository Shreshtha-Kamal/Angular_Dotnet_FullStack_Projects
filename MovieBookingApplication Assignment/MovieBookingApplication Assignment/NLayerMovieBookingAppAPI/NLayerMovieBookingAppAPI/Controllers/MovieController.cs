using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerMovieBookingAppBLL.IServices;
using NLayerMovieBookingAppBLL.Models;
using NLayerMovieBookingAppDomain.Common;
using System.Net;

namespace NLayerMovieBookingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("AddMovie")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddMovie([FromBody]MovieModel movie)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (movie == null)
                {
                    return BadRequest();
                }
                var movieDetails = await _movieService.AddMovie(movie);
                if (movieDetails.StatusCode == HttpStatusCode.Created)
                {
                    return StatusCode((int)movieDetails.StatusCode, movieDetails.Data);
                }
                return StatusCode((int)movieDetails.StatusCode);
            }
            catch (ApiException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Internal ServerError Occured", ex.Exception });
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "Internal ServerError Occured", ex });
            }
        }

        [HttpGet("getMovie/{id}")]
        [Authorize]
        public async Task<IActionResult> GetMovieDetail([FromRoute]Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var movieResponse = await _movieService.GetMovieById(id);
                if (movieResponse.StatusCode == HttpStatusCode.OK)
                {
                    return StatusCode((int)HttpStatusCode.OK, movieResponse.Data);
                }
                return NotFound();
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

        [HttpGet("getAllMovies")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllMovies()
        {
            try
            {
                var allMovies = await _movieService.GetAllMovies();
                if (allMovies.Data.Count == 0)
                {
                    return NotFound();
                }
                return Ok(allMovies.Data);
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
