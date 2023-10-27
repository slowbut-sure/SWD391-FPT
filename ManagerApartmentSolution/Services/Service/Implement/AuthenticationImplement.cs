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
using Services.Models.Response.Response;
using Services.Models.Request;
using Domain.Enums.Role;
using Services.Helpers;
using Microsoft.Identity.Client;
using Services.Models.Response.Response.StaffResponse;
using Services.Models.Response.Response.OwnerResponse;
using Services.Models.Response.Response.TennantResponse;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ManagerApartment.Models;

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

        public async Task<AuthResponse<ResponseAccountStaff>> ValidateStaff(RequestLogin accountLogin)
        {
            //check account has Exist or not
            var Staff = await _staffRepository.GetAccountByEmail(accountLogin.Email);
            var response = new AuthResponse<ResponseAccountStaff>();
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

        public async Task<AuthResponse<ResponseAccountOwner>> ValidateOwner(RequestLogin accountLogin)
        {
            //check account name has Exist or not
            var owner = await _unitOfWork.Owner.GetByEmail(accountLogin.Email);
            var response = new AuthResponse<ResponseAccountOwner>();
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

        public async Task<AuthResponse<ResponseAccountTennant>> ValidateTennant(RequestLogin accountLogin)
        {
            //check account name has Exist or not
            var tennant = await _unitOfWork.Tennant.GetByEmail(accountLogin.Email);
            var response = new AuthResponse<ResponseAccountTennant>();
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

        public async Task<AuthResponse<AccountResponse>> Validate(RequestLogin accountLogin)
        {
            var response = new AuthResponse<AccountResponse>();

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
                    Staff.Role = role;
                }
                else
                {
                    role = RolePositionStaff.STAFF.ToString();
                    Staff.Role = role;
                }

                //_cacheManager.Set(Staff.StaffId.ToString(), true, 60);
                response.Data = _mapper.Map<ResponseAccountStaff>(Staff);
                response.Token = _authentication.GenerateToken(Staff, _appConfiguration.JWTSecretKey, role);
                response.Success = true;
                response.Message = "Login Success";
            }
                    


            return response;
        }

        public async Task<AuthResponse<AccountResponse>> ValidateToken(string token)
        {
            var response = new AuthResponse<AccountResponse>();
            if (string.IsNullOrEmpty(token))
            {
                response.Message = "Token is required";
                response.Success = false;
                return response;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                RequireExpirationTime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                // Read token
                var tokenData = tokenHandler.ReadJwtToken(token);

                var tokenExp = tokenData.Claims.FirstOrDefault(Claim => Claim.Type.Equals("exp"))!.Value;
                var tokenDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(tokenExp)).UtcDateTime;
                var now = DateTime.UtcNow;

                if (now > tokenDate)
                {
                    // Expired = true
                    response.Success = false;
                    response.Message = "Token is expired";
                    return response;
                }
                else
                {
                    var roleClaim = tokenData.Claims.FirstOrDefault(claim => claim.Type.Equals("role"));
                    var emailClaim = tokenData.Claims.FirstOrDefault(claim => claim.Type.Equals("email"));
                    if (roleClaim != null)
                    {
                        var role = roleClaim.Value;
                        if (role.Equals(RolePositionStaff.STAFFMANAGER.ToString()) || role.Equals(RolePositionStaff.STAFF.ToString()))
                        {                          
                            if (emailClaim != null) 
                            {
                                var email = emailClaim.Value;
                                var staff = await _unitOfWork.Staff.GetAccountByEmail(email);
                                response.Data = _mapper.Map<ResponseAccountStaff>(staff);
                                response.Token = _authentication.GenerateToken(staff, _appConfiguration.JWTSecretKey, role);
                                response.Success = true;
                                response.Message = "Renew Token";
                                return response;
                            }
                            else
                            {
                                response.Success = false;
                                response.Message = "Email claim not found in the JWT.";
                                return response;
                            }
                        }
                        else if (role.Equals(ROLEACCOUNT.OWNER.ToString()))
                        {                            
                            if (emailClaim != null)
                            {
                                var email = emailClaim.Value;
                                var owner = await _unitOfWork.Owner.GetByEmail(email);
                                response.Data = _mapper.Map<ResponseAccountOwner>(owner);
                                response.Token = _authentication.GenerateToken(owner, _appConfiguration.JWTSecretKey, role);
                                response.Success = true;
                                response.Message = "Renew Token";
                                return response;
                            }
                            else
                            {
                                response.Success = false;
                                response.Message = "Email claim not found in the JWT.";
                                return response;
                            }
                        }
                        else if (role.Equals(ROLEACCOUNT.TENANT.ToString()))
                        {
                            if (emailClaim != null)
                            {
                                var email = emailClaim.Value;
                                var tennant = await _unitOfWork.Tennant.GetByEmail(email);
                                response.Data = _mapper.Map<ResponseAccountTennant>(tennant);
                                response.Token = _authentication.GenerateToken(tennant, _appConfiguration.JWTSecretKey, role);
                                response.Success = true;
                                response.Message = "Renew Token";
                                return response;
                            }
                            else
                            {
                                response.Success = false;
                                response.Message = "Email claim not found in the JWT.";
                                return response;
                            }
                        }
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Role claim not found in the JWT.";
                        return response;
                    }


                    return response;
                }
            }
            catch (SecurityTokenExpiredException)
            {
                response.Success = true;
                response.Message = "Token is expired";
                return response;
            }
            catch
            {
                response.Message = "Invalid token.";
                response.Success = false;
                return response;
            }
        }
    }
 }