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
using Services.Models.Response.StaffResponse;
using Services.Models.Response.OwnerResponse;
using Services.Models.Response.TennantResponse;

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
        IUnitOfWork unitOfWork, IMapper mapper, AppConfiguration appConfiguration, IStaffRepository staffRepository, ICacheManager cacheManager)
        {
            _authentication = authentication;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appConfiguration = appConfiguration;
            _staffRepository = staffRepository;
            _cacheManager = cacheManager;
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

        public async Task<LoginResponse<ResponseAccountStaff>> ValidateStaff(RequestLogin accountLogin)
        {
            //check account has Exist or not
            var Staff = await _staffRepository.GetAccountByEmail(accountLogin.Email);
            var response = new LoginResponse<ResponseAccountStaff>();
            if (Staff == null)
            {
                response.Success = false;
                response.Message = "Username Not Exist";
                return response;
            }
            var result = _authentication.Verify(Staff.Password, accountLogin.Password);
            if (!result)
            {
                response.Success = false;
                response.Message = "Invalid Password";
                return response;
            }

            //var check = await _cacheManager.Get<bool>(Staff.StaffId.ToString());
            //if (check)
            //{
            //    response.Success = false;
            //    response.Messenger = "This Account has Login";
            //    return response;
            //}

            string role = Staff.Role;
            if (Int32.Parse(role) == (int)RolePositionStaff.STAFFMANAGER)
            {
                role = RolePositionStaff.STAFFMANAGER.ToString();
            }
            else
            {
                role = RolePositionStaff.STAFF.ToString();
            }

            //_cacheManager.Set(Staff.StaffId.ToString(), true, 60);
            response.Data = _mapper.Map<ResponseAccountStaff>(Staff);
            response.Token = _authentication.GenerateToken(Staff, _appConfiguration.JWTSecretKey, role);
            response.Success = true;
            response.Message = "Login Success";
            return response;
        }

        public async Task<LoginResponse<ResponseAccountOwner>> ValidateOwner(RequestLogin accountLogin)
        {
            //check account name has Exist or not
            var owner = await _unitOfWork.Owner.GetByEmail(accountLogin.Email);
            var response = new LoginResponse<ResponseAccountOwner>();
            if (owner == null)
            {
                response.Success = false;
                response.Message = "Username Not Exist";
                return response;
            }
            var result = _authentication.Verify(owner.Password, accountLogin.Password);
            if (!result)
            {
                response.Success = false;
                response.Message = "Invalid Password";
                return response;
            }

            //var check = await _cacheManager.Get<bool>(owner.OwnerId.ToString());
            //if (check)
            //{
            //    response.Success = false;
            //    response.Messenger = "This Account has Login";
            //    return response;
            //}

            string role = ROLEACCOUNT.OWNER.ToString();

            //_cacheManager.Set(owner.OwnerId.ToString(), true, 60);
            response.Data = _mapper.Map<ResponseAccountOwner>(owner);
            response.Token = _authentication.GenerateToken(owner, _appConfiguration.JWTSecretKey, role);
            response.Success = true;
            response.Message = "Login Success";
            return response;
        }

        public async Task<LoginResponse<ResponseAccountTennant>> ValidateTennant(RequestLogin accountLogin)
        {
            //check account name has Exist or not
            var tennant = await _unitOfWork.Tennant.GetByEmail(accountLogin.Email);
            var response = new LoginResponse<ResponseAccountTennant>();
            if (tennant == null)
            {
                response.Success = false;
                response.Message = "Username Not Exist";
                return response;
            }
            var result = _authentication.Verify(tennant.Password, accountLogin.Password);
            if (!result)
            {
                response.Success = false;
                response.Message = "Invalid Password";
                return response;
            }

            //var check = await _cacheManager.Get<bool>(tennant.TennantId.ToString());
            //if (check)
            //{
            //    response.Success = false;
            //    response.Messenger = "This Account has Login";
            //    return response;
            //}

            string role = ROLEACCOUNT.TENANT.ToString();

            //_cacheManager.Set(tennant.TennantId.ToString(), true, 60);
            response.Data = _mapper.Map<ResponseAccountTennant>(tennant);
            response.Token = _authentication.GenerateToken(tennant, _appConfiguration.JWTSecretKey, role);
            response.Success = true;
            response.Message = "Login Success";
            return response;
        }

        public async Task<LoginResponse<AccountResponse>> Validate(RequestLogin accountLogin)
        {
            var response = new LoginResponse<AccountResponse>();

            var Staff = await _unitOfWork.Staff.GetAccountByEmail(accountLogin.Email);
            var tennant = await _unitOfWork.Tennant.GetByEmail(accountLogin.Email);
            var owner = await _unitOfWork.Owner.GetByEmail(accountLogin.Email);
            if (Staff == null)
            {
                if (tennant == null)
                {
                    if (owner == null)
                    {
                        response.Success = false;
                        response.Message = "Username Not Exist";
                        return response;
                    }
                    else
                    {
                        var result = _authentication.Verify(owner.Password, accountLogin.Password);
                        if (!result)
                        {
                            response.Success = false;
                            response.Message = "Invalid Password";
                            return response;
                        }

                        //var check = await _cacheManager.Get<bool>(owner.OwnerId.ToString());
                        //if (check)
                        //{
                        //    response.Success = false;
                        //    response.Messenger = "This Account has Login";
                        //    return response;
                        //}

                        string role = ROLEACCOUNT.OWNER.ToString();

                        //_cacheManager.Set(owner.OwnerId.ToString(), true, 60);
                        response.Data = _mapper.Map<ResponseAccountOwner>(owner);
                        response.Token = _authentication.GenerateToken(owner, _appConfiguration.JWTSecretKey, role);
                        response.Success = true;
                        response.Message = "Login Success";
                    }
                }
                else
                {
                    var result = _authentication.Verify(tennant.Password, accountLogin.Password);
                    if (!result)
                    {
                        response.Success = false;
                        response.Message = "Invalid Password";
                        return response;
                    }

                    //var check = await _cacheManager.Get<bool>(tennant.TennantId.ToString());
                    //if (check)
                    //{
                    //    response.Success = false;
                    //    response.Messenger = "This Account has Login";
                    //    return response;
                    //}

                    string role = ROLEACCOUNT.TENANT.ToString();

                    //_cacheManager.Set(tennant.TennantId.ToString(), true, 60);
                    response.Data = _mapper.Map<ResponseAccountTennant>(tennant);
                    response.Token = _authentication.GenerateToken(tennant, _appConfiguration.JWTSecretKey, role);
                    response.Success = true;
                    response.Message = "Login Success";
                }

            }    
            else
            {
                var result = _authentication.Verify(Staff.Password, accountLogin.Password);
                if (!result)
                {
                    response.Success = false;
                    response.Message = "Invalid Password";
                    return response;
                }

                //var check = await _cacheManager.Get<bool>(Staff.StaffId.ToString());
                //if (check)
                //{
                //    response.Success = false;
                //    response.Messenger = "This Account has Login";
                //    return response;
                //}

                string role = Staff.Role;
                if (Int32.Parse(role) == (int)RolePositionStaff.STAFFMANAGER)
                {
                    role = RolePositionStaff.STAFFMANAGER.ToString();
                }
                else
                {
                    role = RolePositionStaff.STAFF.ToString();
                }

                //_cacheManager.Set(Staff.StaffId.ToString(), true, 60);
                response.Data = _mapper.Map<ResponseAccountStaff>(Staff);
                response.Token = _authentication.GenerateToken(Staff, _appConfiguration.JWTSecretKey, role);
                response.Success = true;
                response.Message = "Login Success";
            }
                    


            return response;
        }
    }
 }