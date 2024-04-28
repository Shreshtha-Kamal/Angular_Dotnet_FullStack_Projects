using BillManagementDomain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementDAL.IRepository
{
    public interface IAuthRepository
    {
        public Task<ApplicationUser?> GetUserByEmail(string email);

        public Task<ApplicationUser?> GetUserByPhoneNumber(string phoneNumber);
        public Task<IdentityResult> CreateUser(ApplicationUser user, string password, string role);
        public Task<ApplicationUser?> GetUserById(string id);
        public Task<bool> IsValidPassword(ApplicationUser user, string password);
        public Task<JwtSecurityToken> CreateLoginToken(ApplicationUser user);
        public Task<List<ApplicationUser>?> GetAllNormalUser();
    }
}
