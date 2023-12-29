using System.Text;
using ASBAL;
using ASModels.Astrooff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Server.Helper;
using ASModels;
using Microsoft.EntityFrameworkCore;
//using AstroOfficeWeb.Client.Helper;
using Microsoft.AspNetCore.Authorization;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Helper;

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

                var userDTO = new UserDTO()
                {
                    UserName = aUser.Username ?? "",
                    CanAdd = aUser.CanAdd.GetValueOrDefault(),
                    CanEdit = aUser.CanEdit.GetValueOrDefault(),
                    CanReport = aUser.CanReport.GetValueOrDefault(),
                    ActiveUserId = aUser.Sno,
                    AdminUser = aUser.Adminuser.GetValueOrDefault()
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
                response.Message = AccountMessageConst.SignUpSuccessful;
            }
            catch (Exception ex)
            {
                response.IsAuthSuccessful = false;
                response.Message = ex.Message;
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

                var userDTO = new UserDTO()
                {
                    UserName = aUser.Username ?? "",
                    CanAdd = aUser.CanAdd.GetValueOrDefault(),
                    CanEdit = aUser.CanEdit.GetValueOrDefault(),
                    CanReport = aUser.CanReport.GetValueOrDefault(),
                    ActiveUserId = aUser.Sno,
                    AdminUser = aUser.Adminuser.GetValueOrDefault()
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
                response.Message = AccountMessageConst.SignUpSuccessful;
            }
            catch
            {
                response.IsAuthSuccessful = false;
                response.Message = ApiMessageConst.ServerError;
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
        public IActionResult SignUp([FromBody] SignUpMasterRequest request)
        {
            //if (User.IsInRole(ApplicationConst.Role_Admin))
            //{

            //}

            var response = new SignUpResponse();
            response.IsRegisterationSuccessful = false;
            response.Success = false;
            try
            {

                var user = _balUser.UserNameSearch(request.UserName);

                if (user != null)
                {
                    response.Message = AccountMessageConst.UserExist;
                    goto returnResponse;
                }

                var mobileUserName = _balUser.GetUserByMobileNumber(request.PhoneNumber);

                if (mobileUserName != null)
                {
                    response.Message = AccountMessageConst.MobileNumberExist;
                    goto returnResponse;
                }
            }
            catch
            {
                response.Message = ApiMessageConst.ServerError;
                goto returnResponse;
            }

            if (ModelState.IsValid)
            {
                var aUser = new AUser()
                {
                    Active = true,
                    Adminuser = request.UserPermission?.AdminUser ?? false,
                    CanAdd = request.UserPermission?.CanAdd ?? false,
                    CanEdit = request.UserPermission?.CanEdit ?? false,
                    CanReport = request.UserPermission?.CanReport ?? false,
                    Password = request.Password,
                    Username = request.UserName,
                    MobileNumber = request.PhoneNumber,
                    Sno = request.Sno
                };

                try
                {
                    if (aUser.Sno == 0)
                    {
                        _balUser.AddUser(aUser);
                    }
                    else
                    {
                        aUser.Password = ENCEK.ENCEK.CellGell_ENC(aUser.Password, "cellgell.com");
                        _balUser.UpdateUser(aUser);
                    }
                    response.IsRegisterationSuccessful = true;
                    response.Success = true;

                    response.Data = aUser.Sno;
                    response.Message = AccountMessageConst.SignUpSuccessful;

                }
                catch (Exception ex)
                {
                    _ = ex;
                    response.Message = ApiMessageConst.ServerError;
                }
            }
            else
            {
                response.Message = AccountMessageConst.SignUpFailed;
            }

        returnResponse:
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
            };

            if (user.Username!.Equals(ApplicationConst.Role_Member, StringComparison.CurrentCultureIgnoreCase))
            {
                claims.Add(new Claim(ClaimTypes.Role, ApplicationConst.Role_Member));
            }
            else if (user.Username!.Equals(ApplicationConst.Role_Astrologer, StringComparison.CurrentCultureIgnoreCase))
            {
                claims.Add(new Claim(ClaimTypes.Role, ApplicationConst.Role_Astrologer));
            }
            else if (user.Username!.Equals(ApplicationConst.Role_Administrator, StringComparison.CurrentCultureIgnoreCase))
            {
                claims.Add(new Claim(ClaimTypes.Role, ApplicationConst.Role_Administrator));
            }
            else if (user.Username!.Equals(ApplicationConst.Role_OrderManager, StringComparison.CurrentCultureIgnoreCase))
            {
                claims.Add(new Claim(ClaimTypes.Role, ApplicationConst.Role_OrderManager));
            }
            else if (user.Username!.Equals("productmanager", StringComparison.CurrentCultureIgnoreCase))
            {
                claims.Add(new Claim(ClaimTypes.Role, ApplicationConst.Role_ProductManager));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, user.Adminuser == true ? "Admin" : "User"));
            }

            return claims;
        }
    }
}
