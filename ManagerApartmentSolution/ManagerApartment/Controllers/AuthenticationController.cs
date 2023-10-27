using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.IUnitOfWork;
using Services.Models.Request;
using Services.Models.Response;
using Services.Models.Response.Response;
using Services.Models.Response.Response.OwnerResponse;
using Services.Models.Response.Response.StaffResponse;
using Services.Models.Response.Response.TennantResponse;
using Services.Servicess;
using System.Net;

namespace ManagerApartment.Controllers
{
    //[Authorize]
    [Route("api/authentication")]
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

        [HttpPost("staff/login")]
        [AllowAnonymous]
        public async Task<ActionResult<DataResponse<ResponseAccountStaff>>> StaffLogin(RequestLogin login)
        {
            var staff = await _authentication.ValidateStaff(login);
            //cấp token
            return Ok(staff);
        }

        [HttpPost("owner/login")]
        [AllowAnonymous]
        public async Task<ActionResult<DataResponse<ResponseAccountOwner>>> OwnerLogin(RequestLogin login)
        {
            var owner = await _authentication.ValidateOwner(login);
            //cấp token
            return Ok(owner);
        }

        [HttpPost("tennant/login")]
        [AllowAnonymous]
        public async Task<ActionResult<DataResponse<ResponseAccountTennant>>> TennantLogin(RequestLogin login)
        {
            var tennant = await _authentication.ValidateTennant(login);
            //cấp token
            return Ok(tennant);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<DataResponse<AccountResponse>>> Login(RequestLogin login)
        {
            var account = await _authentication.Validate(login);
            return Ok(account);
        }

        [HttpPost("logout")]
        public async Task<ActionResult<Boolean>> Logout(int staffId)
        {
            var staff = await _authentication.Logout(staffId);
            //cấp token
            return Ok(staff);
        }

        [HttpPost("token/renew")]
        public async Task<ActionResult<DataResponse<AccountResponse>>> RenewToken()
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            return await _authentication.ValidateToken(token);
        }

    }
}
