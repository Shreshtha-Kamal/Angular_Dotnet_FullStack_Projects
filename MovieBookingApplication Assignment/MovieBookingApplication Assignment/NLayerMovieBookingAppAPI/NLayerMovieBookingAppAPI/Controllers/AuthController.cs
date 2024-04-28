using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerMovieBookingAppBLL.Helper;
using NLayerMovieBookingAppBLL.IServices;
using NLayerMovieBookingAppBLL.Models;
using NLayerMovieBookingAppDomain.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace NLayerMovieBookingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly AuthHelper _helper;
        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _helper = new AuthHelper(httpContextAccessor);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginData loginUser)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // get jwt token
                var response = await _authService.Login(loginUser);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Unauthorized();
                }

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(response.Data),
                    expiration = response.Data.ValidTo
                });
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

        [HttpGet("getUserRole")]
        [Authorize]
        public async Task<IActionResult> GetRole()
        {
            try
            {
                var role = _helper.GetLoggedinUserRole();
                if (role == null)
                {
                    return StatusCode((int)HttpStatusCode.Unauthorized, new {message = "Unauthorized User or Invalid Token"});
                }
                return Ok(new
                {
                    userRole = role
                });
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
    }
}
