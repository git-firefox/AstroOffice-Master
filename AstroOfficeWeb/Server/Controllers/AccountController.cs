using System.Text;
using ASBAL;
using ASModels.Astrooff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Server.Helper;
using ASModels;
using Microsoft.EntityFrameworkCore;
using AstroOfficeWeb.Client.Helper;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //ASDLL 
        private readonly BALUser _balUser;
        private readonly JWTSettings _jwtSettings;

        public AccountController(IOptions<JWTSettings> options, BALUser balUser)
        {
            _balUser = balUser;
            _jwtSettings = options.Value;
        }

        [HttpPost]
        public IActionResult SignIn([FromBody] SignInRequest signInReques)
        {
            var response = new SignInResponse();

            try
            {
                var aUser = _balUser.UserNameSearch(signInReques.UserName);

                if (aUser == null)
                {
                    response.IsAuthSuccessful = false;
                    response.Message = AccountMessageConst.AccountNotFound;
                    goto returnResponse;
                }

                if (!aUser.Active.GetValueOrDefault())
                {
                    response.IsAuthSuccessful = false;
                    response.Message = AccountMessageConst.AccountLocked;
                    goto returnResponse;
                }

                aUser = _balUser.UserLogin(signInReques!.UserName, signInReques!.Password);

                if (aUser.Sno <= 0)
                {
                    response.IsAuthSuccessful = false;
                    response.Message = AccountMessageConst.InvalidCredentials;
                    goto returnResponse;
                }

                var userDTO = new AUserDTO()
                {
                    UserName = aUser.Username ?? "",
                    CanAddNew = aUser.CanAdd.GetValueOrDefault(),
                    CanModify = aUser.CanEdit.GetValueOrDefault(),
                    CanReport = aUser.CanReport.GetValueOrDefault(),
                    ActiveUserId = aUser.Sno,
                    IsAdmin = aUser.Adminuser.GetValueOrDefault()
                };

                var signinCredentials = GetSigningCredentials();
                var claims = GetClaims(aUser);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _jwtSettings.ValidIssuer,
                    audience: _jwtSettings.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials
                );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                response.IsAuthSuccessful = true;
                response.Token = token;
                response.UserDTO = userDTO;
                response.Message = AccountMessageConst.LoginSuccessful;
            }
            catch
            {
                response.IsAuthSuccessful = false;
                response.Message = AccountMessageConst.ServerError;
            }

            returnResponse:
            return Ok(response);
        }

        // GET api/<UserController>/5
        [HttpPost]
        public IActionResult SignInWithOtp([FromBody] SignInWithOtpRequest request)
        {
            var response = new SignInResponse();

            try
            {
                var aUser = _balUser.GetUserByMobileNumber(request!.MobileNumber);

                if (aUser == null)
                {
                    response.IsAuthSuccessful = false;
                    response.Message = AccountMessageConst.MobileNumberNotFound;
                    goto returnResponse;
                }

                if (!aUser.Active.GetValueOrDefault())
                {
                    response.IsAuthSuccessful = false;
                    response.Message = AccountMessageConst.AccountLocked;
                    goto returnResponse;
                }

                if (aUser.MobileOtp != request.Otp)
                {
                    response.IsAuthSuccessful = false;
                    response.Message = SMSMessageConst.InvalidOTP;
                    goto returnResponse;
                }

                var userDTO = new AUserDTO()
                {
                    UserName = aUser.Username ?? "",
                    CanAddNew = aUser.CanAdd.GetValueOrDefault(),
                    CanModify = aUser.CanEdit.GetValueOrDefault(),
                    CanReport = aUser.CanReport.GetValueOrDefault(),
                    ActiveUserId = aUser.Sno,
                    IsAdmin = aUser.Adminuser.GetValueOrDefault()
                };

                var signinCredentials = GetSigningCredentials();
                var claims = GetClaims(aUser);
                var tokenOptions = new JwtSecurityToken(
                    issuer: _jwtSettings.ValidIssuer,
                    audience: _jwtSettings.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials
                );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                response.IsAuthSuccessful = true;
                response.Token = token;
                response.UserDTO = userDTO;
                response.Message = AccountMessageConst.LoginSuccessful;
            }
            catch
            {
                response.IsAuthSuccessful = false;
                response.Message = AccountMessageConst.ServerError;
            }

            returnResponse:
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UserNameSearch(string userName)
        {
            var aUser = _balUser.UserNameSearch(userName);

            return Ok(aUser);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetSelectedUser(long sno)
        {
            var aUser = _balUser.GetSelectedUser(sno);

            return Ok(aUser);
        }

        // POST api/<UserController>
        [Authorize]
        [HttpPut]
        public IActionResult UpdateUser([FromForm] AUser au)
        {
            var aUSer = _balUser.UpdateUser(au);
            return Ok(aUSer);
        }

        [HttpPut]
        public IActionResult UpdateUserPasswordByOtp([FromBody] UpdateUserPasswordByOtpRequest request)
        {
            var response = new ApiResponse<string>();

            var aUser = _balUser.GetUserByMobileNumber(request.MobileNumber);

            if (aUser == null)
            {
                response.Success = false;
                response.Message = AccountMessageConst.MobileNumberNotFound;
                goto returnResponse;
            }

            if (!aUser.Active.GetValueOrDefault())
            {
                response.Success = false;
                response.Message = AccountMessageConst.AccountLocked;
                goto returnResponse;
            }

            if (aUser.MobileOtp != request.Otp)
            {
                response.Success = false;
                response.Message = SMSMessageConst.InvalidOTP;
                goto returnResponse;
            }

            if (request.NewPassword == null || request.Otp == null)
            {
                response.Success = false;
                response.Message = AccountMessageConst.UserPassNotUpdated;
                goto returnResponse;
            }

            if (aUser.Sno == 0)
            {
                response.Success = false;
                response.Message = AccountMessageConst.UserNotFound;
                goto returnResponse;
            }

            if (_balUser.IsUserPassUpdatedByOtp(request.MobileNumber, request.NewPassword, request.Otp))
            {
                response.Success = true;
                response.Message = AccountMessageConst.UserPassUpdated;
            }
            else
            {
                response.Success = false;
                response.Message = AccountMessageConst.UserPassNotUpdated;
            }

            returnResponse:
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var aUSer = _balUser.GetAllUsers();
            return Ok(aUSer);
        }

        [HttpPost]
        public IActionResult SignUp([FromBody] SignUpRequest request)
        {
            var response = new SignUpResponse();

            if (request == null)
            {
                return BadRequest();
            }

            if (_balUser.GetAllUsers().Any(a => a.Username == request.UserName && a.MobileNumber == request.PhoneNumber))
            {
                response.IsRegisterationSuccessful = false;
                response.Errors = new List<string>() { "UserName or PhoneNumber already exists." };
                return Ok(response);
            }

            if (ModelState.IsValid)
            {
                var aUser = new AUser()
                {
                    Active = true,
                    Adminuser = false,
                    CanAdd = false,
                    CanEdit = false,
                    CanReport = false,
                    Password = request.Password,
                    Username = request.UserName,
                    MobileNumber = request.PhoneNumber
                };

                try
                {
                    _balUser.AddUser(aUser);
                    response.IsRegisterationSuccessful = true;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    response.IsRegisterationSuccessful = false;
                }
            }

            var allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            response.Errors = allErrors;

            return Ok(response);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private List<Claim> GetClaims(AUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Sno.ToString()),
                new Claim(ClaimTypes.Name, user.Username ?? string.Empty),
                //new Claim("isAdminUser", user.Adminuser?.ToString() ?? "false"),
                new Claim("canAdd", user.CanAdd?.ToString() ?? "false"),
                new Claim("canEdit", user.CanEdit?.ToString() ?? "false"),
                new Claim("canReport", user.CanReport?.ToString() ?? "false"),
                new Claim(ClaimTypes.Role, user.Adminuser == true ? "Admin" : "User"),
            };
            return claims;
        }
    }
}
