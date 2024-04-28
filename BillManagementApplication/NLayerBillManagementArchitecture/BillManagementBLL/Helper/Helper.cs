using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementBLL.Helper
{
    public class AuthHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {

            var claimsIdentity = _httpContextAccessor.HttpContext?.User?.Identities.FirstOrDefault(item => item.Claims.Any());
            var claims = claimsIdentity?.Claims;
            string authenticatedUserId = claims?.FirstOrDefault(item => item.Type == ClaimTypes.GivenName)?.Value;

            return authenticatedUserId;
        }

        public string GetLoggedinUserRole()
        {
            var claimsIdentity = _httpContextAccessor.HttpContext?.User?.Identities.FirstOrDefault(item => item.Claims.Any());
            var claims = claimsIdentity?.Claims;

            var userRole = claims?.FirstOrDefault(Item => Item.Type == ClaimTypes.Role)?.Value;

            return userRole;
        }
    }
}
