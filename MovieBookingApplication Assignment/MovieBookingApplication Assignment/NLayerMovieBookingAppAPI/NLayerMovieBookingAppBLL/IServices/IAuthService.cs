using NLayerMovieBookingAppBLL.Models;
using NLayerMovieBookingAppDomain.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppBLL.IServices
{
    public interface IAuthService
    {
        public Task<ServiceResult<JwtSecurityToken>> Login(LoginData loginData);
    }
}
