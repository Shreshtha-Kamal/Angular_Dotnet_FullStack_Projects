using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NLayerMovieBookingAppDAL.IRepository;
using NLayerMovieBookingAppDomain.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppDAL.Repository
{
    public class AuthRepository: IAuthRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<IdentityUser?> GetUserByUserName(string username)
        {
            try
            {
                return await _userManager.FindByNameAsync(username);
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }
        public async Task<bool> IsValidPassword(IdentityUser user, string password)
        {
            try
            {
                var result = await _userManager.CheckPasswordAsync(user, password);
                return result;
            }
            catch (Exception ex)
            {

                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }

        public async Task<JwtSecurityToken> CreateLoginToken(IdentityUser user)
        {
            //create auth claims
            try
            {
                var authClaims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.UserName),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new(ClaimTypes.Email, user.Email),
                    new(ClaimTypes.GivenName, user.Id)
                };
                var userRole = await _userManager.GetRolesAsync(user);
                foreach (var role in userRole)
                {
                    authClaims.Add(new(ClaimTypes.Role, role));
                }

                //generate jwt Token
                var jwtToken = GetToken(authClaims);
                return jwtToken;
            }
            catch (Exception ex)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            var jwtToken = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256)
                );
            return jwtToken;
        }
    }
}
