using BillManagementBLL.Models;
using BillManagementDomain.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementBLL.IServices
{
    public interface IAuthService
    {
        public Task<string> RegisterUser(ApplicationUserModel registerUser);
        public Task<JwtSecurityToken> Login(LoginData loginData);
        public Task<UserDetailDTO?> GetUserDetailById(string id);
        public Task<List<UserWithLastBillDetailDTO>?> GetAllUserWithLastBillDetail();
    }
}
