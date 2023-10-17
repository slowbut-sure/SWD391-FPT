﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Request;
using Services.Models.Response;
using Services.Models.Response.StaffResponse;
using Services.Servicess;
using System.Net;

namespace ManagerApartment.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authentication;
        private readonly IUnitOfWork _unitOfWork;
        public AuthenticationController(AuthenticationService authentication, IUnitOfWork unitOfWork)
        {
            _authentication = authentication;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseAccountStaff>>> GetStaffs()
        {
            try
            {
                var account = _unitOfWork.Staff.GetAll();
                return Ok(new
                {
                    Success = HttpStatusCode.OK,
                    Message = "Success",
                    Data = account
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = HttpStatusCode.InternalServerError,
                    Message = "Failed",
                    Data = ex.Message
                });
            }
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Login(RequestLogin login)
        {
            var staff = _authentication.Validate(login);
            //cấp token
            return Ok(staff);
        }

        [HttpPost("Logout")]
        public async Task<ActionResult<Boolean>> Logout(int staffId)
        {
            var staff = _authentication.Logout(staffId);
            //cấp token
            return Ok(staff);
        }

    }
}