using Microsoft.AspNetCore.Http;
using NLayerMovieBookingAppDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppBLL.Helper
{
    public class AuthHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetUserId()
        {

            try
            {
                var claimsIdentity = _httpContextAccessor.HttpContext?.User?.Identities.FirstOrDefault(item => item.Claims.Any());
                var claims = claimsIdentity?.Claims;
                string authenticatedUserId = claims?.FirstOrDefault(item => item.Type == ClaimTypes.GivenName)?.Value;

                return authenticatedUserId;
            }
            catch (Exception ex)
            {

                throw new ApiException(HttpStatusCode.InternalServerError, ex);
            }
        }

        public string? GetLoggedinUserRole()
        {
            try
            {
                var claimsIdentity = _httpContextAccessor.HttpContext?.User?.Identities.FirstOrDefault(item => item.Claims.Any());
                var claims = claimsIdentity?.Claims;

                var userRole = claims?.FirstOrDefault(Item => Item.Type == ClaimTypes.Role)?.Value;

                return userRole;
            }
            catch (Exception ex)
            {

                throw new ApiException(HttpStatusCode.InternalServerError, ex);         
            }
        }
    }
}
