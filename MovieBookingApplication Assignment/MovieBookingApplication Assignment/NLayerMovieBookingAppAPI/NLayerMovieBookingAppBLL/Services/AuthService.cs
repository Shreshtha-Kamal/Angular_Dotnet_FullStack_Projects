using NLayerMovieBookingAppBLL.IServices;
using NLayerMovieBookingAppBLL.Models;
using NLayerMovieBookingAppDAL.IRepository;
using NLayerMovieBookingAppDAL.Repository;
using NLayerMovieBookingAppDomain.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppBLL.Services
{
    public class AuthService: IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<ServiceResult<JwtSecurityToken>> Login(LoginData loginData)
        {
            try
            {
                var existingUser = await _authRepository.GetUserByUserName(loginData.UserName);
                if (existingUser == null)
                {
                    return new ServiceResult<JwtSecurityToken>(HttpStatusCode.Unauthorized);
                }
                var result = await _authRepository.IsValidPassword(existingUser, loginData.Password);
                if (result == false)
                {
                    return new ServiceResult<JwtSecurityToken>(HttpStatusCode.Unauthorized);
                }
                var jwtToken = await _authRepository.CreateLoginToken(existingUser);
                return new ServiceResult<JwtSecurityToken>(HttpStatusCode.OK, jwtToken);
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
