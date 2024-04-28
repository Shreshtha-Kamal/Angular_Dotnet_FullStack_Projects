using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppDAL.IRepository
{
    public interface IAuthRepository
    {
        public Task<IdentityUser?> GetUserByUserName(string username);
        public Task<bool> IsValidPassword(IdentityUser user, string password);
        public Task<JwtSecurityToken> CreateLoginToken(IdentityUser user);
    }
}
