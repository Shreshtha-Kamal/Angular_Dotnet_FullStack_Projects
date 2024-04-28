using AutoMapper;
using BillManagementBLL.IServices;
using BillManagementBLL.Models;
using BillManagementDAL.IRepository;
using BillManagementDomain.DTO;
using BillManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementBLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IBillRepository _billRepository;
        private Mapper _userMapper;
        private Mapper _userDetailMapper;
        public AuthService(IAuthRepository authRepository, IBillRepository billRepository)
        {
            _authRepository = authRepository;
            _billRepository = billRepository;
            var _configUser = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, ApplicationUserModel>().ReverseMap();
            });
            this._userMapper = new Mapper(_configUser);

            var configUserDetail = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, UserDetailDTO>().ReverseMap();
            });
            _userDetailMapper = new Mapper(configUserDetail);
        }

        public async Task<string> RegisterUser(ApplicationUserModel registerUser)
        {
            var existingUserWithEmail= await _authRepository.GetUserByEmail(registerUser.Email);
            var existingUserWithPhoneNumber= await _authRepository.GetUserByPhoneNumber(registerUser.PhoneNumber);
            if(existingUserWithEmail != null && existingUserWithPhoneNumber != null)
            {
                return null;
            }
            //ApplicationUser applicationUser = _userMapper.Map<ApplicationUserModel,ApplicationUser>(registerUser);
            var applicationUser = new ApplicationUser
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                EmailConfirmed= true,
                Name = registerUser.Name,
                PhoneNumber = registerUser.PhoneNumber,
                AlternatePhoneNumber = registerUser.AlternatePhoneNumber,
                Address = registerUser.Address,
                PinCode = registerUser.Pincode,
                LoadAllowed = registerUser.LoadAllowed,
                CreatedAt = registerUser.CreatedAt
            };
            var result = await _authRepository.CreateUser(applicationUser, registerUser.Password, registerUser.Role);
            if (!result.Succeeded)
            {
                return null;
            }
            return "User Created Successfully";
        }

        public async Task<JwtSecurityToken> Login(LoginData loginData)
        {
            var existingUser= await _authRepository.GetUserByEmail(loginData.Email);
            if(existingUser == null)
            {
                return null;
            }
            var result= await _authRepository.IsValidPassword(existingUser, loginData.Password);
            if(result==false)
            {
                return null;
            }
            var jwtToken = await _authRepository.CreateLoginToken(existingUser);
            return jwtToken;
        }

        public async Task<UserDetailDTO?>GetUserDetailById(string id)
        {
            var userFromDb= await _authRepository.GetUserById(id);
            if(userFromDb == null)
            {
                return null;
            }
            var userDetail = _userDetailMapper.Map<ApplicationUser, UserDetailDTO>(userFromDb);
            return userDetail;
        }

        public async Task<List<UserWithLastBillDetailDTO>?> GetAllUserWithLastBillDetail()
        {
            var usersWithLastBillDetail= new List<UserWithLastBillDetailDTO>();
            var allUserDetail = await _authRepository.GetAllNormalUser();
            foreach (var user in allUserDetail)
            {
                var userRecentBill= await _billRepository.GetMostRecentBillForUser(user.Id.ToString());
                UserWithLastBillDetailDTO userWithLastBillDetailDTO = new UserWithLastBillDetailDTO();
                userWithLastBillDetailDTO.UserId = user.Id;
                userWithLastBillDetailDTO.Name = user.Name;
                userWithLastBillDetailDTO.Pincode = user.PinCode;
                userWithLastBillDetailDTO.LoadAllowed = user.LoadAllowed;
                userWithLastBillDetailDTO.LatestBillAmount = userRecentBill?.TotalAmount;
                userWithLastBillDetailDTO.BillStatus = userRecentBill?.Status.ToString();
                usersWithLastBillDetail.Add(userWithLastBillDetailDTO);
            }
            return usersWithLastBillDetail;
        }

    }
}
