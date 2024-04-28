using BillManagementDAL.IRepository;
using BillManagementDomain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementDAL.Repository
{
    public class AuthRepository: IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<ApplicationUser?> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser?> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<IdentityResult> CreateUser(ApplicationUser applicationUser,string password, string role)
        {
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.AddToRoleAsync(applicationUser, role);
            }
            return result;
        }

        public async Task<bool> IsValidPassword(ApplicationUser user, string password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }

        public async Task<JwtSecurityToken> CreateLoginToken(ApplicationUser user)
        {
            // create auth claims
            var authClaims = new List<Claim>
            {
                new (ClaimTypes.Name, user.Name),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.GivenName, user.Id)
            };
            if (!string.IsNullOrEmpty(user.LoadAllowed.ToString()))
            {
                authClaims.Add(new(ClaimTypes.Anonymous, user.LoadAllowed.ToString()));
            }
            var userRole = await _userManager.GetRolesAsync(user);
            foreach (var role in userRole)
            {
                authClaims.Add(new (ClaimTypes.Role, role));
            }
            var jwtToken = GetToken(authClaims);
            return jwtToken;
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

        public async Task<ApplicationUser?>GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<List<ApplicationUser>?> GetAllNormalUser()
        {
            var users= await _userManager.Users.Where(u=>u.LoadAllowed!=null).ToListAsync();
            return users;
        }
    }
}
