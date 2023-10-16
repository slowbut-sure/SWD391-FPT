using System.Security.Cryptography;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Services.Authentication;
using Services;
using Services.Authentication.Implement;
using Services.Interfaces.IUnitOfWork;
using Services.Interfaces;
using Services.Models.Response;
using Services.Models.Request;
using Domain.Enums.Role;
using Services.Helpers;
using Microsoft.Identity.Client;

namespace Services.Servicess.Implement
{

    public class AuthenticationImplement : AuthenticationService
    {
        private IAuthentication _authentication;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly ICacheManager _cacheManager;
        private AppConfiguration _appConfiguration;
        private IStaffRepository _staffRepository;

        public AuthenticationImplement(IAuthentication authentication,
        IUnitOfWork unitOfWork, IMapper mapper, AppConfiguration appConfiguration, IStaffRepository staffRepository)
        {
            _authentication = authentication;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appConfiguration = appConfiguration;
            _staffRepository = staffRepository;
        }


        public async Task<Boolean> Logout(int accountId)
        {
            try
            {
                _cacheManager.Remove(accountId.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public async Task<LoginResponse> Validate(RequestLogin accountLogin)
        {
            //check account has Exist or not
            var Staff = await _staffRepository.GetAccount(accountLogin.Name);
            var response = new LoginResponse();
            if (Staff == null)
            {
                response.Success = false;
                response.Messenger = "Username Not Exist";
                return response;
            }
            var result = _authentication.Verify(Staff.Password, accountLogin.Password);
            if (!result)
            {
                response.Success = false;
                response.Messenger = "Invalid Password";
                return response;
            }

            var check = await _cacheManager.Get<bool>(Staff.StaffId.ToString());
            if (check)
            {
                response.Success = false;
                response.Messenger = "This Account has Login";
                return response;
            }

            string role = Staff.Role;
            if (role.Equals(ROLEACCOUNT.ADMIN.ToString()))
            {
                var staffById = await _staffRepository.GetStaffById(Staff.StaffId);
                if (staffById != null)
                {
                    role = RolePositionStaff.STAFFMANAGER.ToString();
                }
                else
                {
                    role = RolePositionStaff.STAFF.ToString();
                }
            }

            _cacheManager.Set(Staff.StaffId.ToString(), true, 60);
            response.Data = _authentication.GenerateToken(Staff, _appConfiguration.JWTSecretKey, role);
            response.Success = true;
            response.Messenger = "Login Success";
            return response;
        }


    }
}