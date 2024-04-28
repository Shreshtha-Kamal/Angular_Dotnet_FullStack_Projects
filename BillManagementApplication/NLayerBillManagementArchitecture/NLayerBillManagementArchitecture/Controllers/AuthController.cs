using BillManagementBLL.Helper;
using BillManagementBLL.IServices;
using BillManagementBLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace NLayerBillManagementArchitecture.Controllers
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
        [HttpPost("registerUser")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Register( ApplicationUserModel user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response= await _authService.RegisterUser(user);
            if (response == null)
            {
                return BadRequest(new
                {
                    errorResponse= "User with same mail or phone number already exist"
                });
            }
            return Ok(new
            {
                response
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginData loginUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var response = await _authService.Login(loginUser);
            if (response == null)
            {
                return Unauthorized();
            }
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(response),
                expiration = response.ValidTo
            });
        }

        [HttpGet("getUserbyId/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserDetailById([FromRoute]string id)
        {
            var userDetail = await _authService.GetUserDetailById(id);
            if(userDetail == null)
            {
                return NotFound();
            }
            return Ok(userDetail);
        }

        [HttpGet("getUserRole")]
        [Authorize]
        public async Task<IActionResult> GetRole()
        {
            var role = _helper.GetLoggedinUserRole();
            if (role == null)
            {
                return BadRequest("Unauthorised User");
            }
            return Ok(new
            {
                userRole = role
            });
        }

        [HttpGet("getAuthUserId")]
        [Authorize]
        public async Task<IActionResult> GetUserData()
        {
            var userId= _helper.GetUserId();
            if(userId == null)
            {
                return BadRequest("Unauthorised User");
            }
            return Ok(new
            {
                userId
            });
        }

        [HttpGet("getAllUsersWithBillDetail")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllUsersWithRecentBillDetail()
        {
            var usersWithLastBillDetail= await _authService.GetAllUserWithLastBillDetail();
            if (usersWithLastBillDetail == null)
            {
                return NotFound();
            }
            return Ok(usersWithLastBillDetail);
        }
    }
}
