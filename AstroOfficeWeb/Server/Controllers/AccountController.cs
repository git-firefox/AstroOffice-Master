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
using AutoMapper;
using AstroOfficeWeb.Shared.Utilities;

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
        private readonly IMapper _mapper;

        public AccountController(IOptions<JWTSettings> options, BALUser balUser, IMapper mapper)
        {
            _balUser = balUser;
            _jwtSettings = options.Value;
            _mapper = mapper;
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
            var response = new ApiResponse<List<BaseUserDTO>>();
            var aUsers = _balUser.GetAllUsers();
            var userDTOs = _mapper.Map<List<BaseUserDTO>>(aUsers);
            response.Data = userDTOs;
            return Ok(response);
        }

        [HttpPost]
        public IActionResult SignUp([FromBody] SignUpRequest request)
        {
            var response = new ApiResponse<string>();
            response.Success = false;

            try
            {
                var user = _balUser.UserNameSearch(request.UserName);
                if (user != null)
                {
                    response.Message = AccountMessageConst.UserExist;
                    goto returnResponse;
                }


                var mobileUserName = _balUser.GetUserByMobileNumber(request.MobileNumber);
                if (mobileUserName != null)
                {
                    response.Message = AccountMessageConst.MobileNumberExist;
                    goto returnResponse;
                }

                if (!ModelState.IsValid)
                {
                    response.Message = AccountMessageConst.SignUpFailed;
                    goto returnResponse;
                }

                _balUser.AddUser(new AUser()
                {
                    Active = true,
                    Adminuser = false,
                    CanAdd = false,
                    CanEdit = false,
                    CanReport = false,
                    Password = request.Password,
                    Username = request.UserName,
                    MobileNumber = request.MobileNumber,
                    Role = UserRole.Guest.ToString()
                });

                response.Success = true;
                response.Message = AccountMessageConst.SignUpSuccessful;
            }
            catch
            {
                response.Success = false;
                response.Message = ApiMessageConst.ServerError;
            }

        returnResponse:
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SignUpMaster([FromBody] SignUpMasterRequest request)
        {
            var response = new ApiResponse<long>();
            response.Success = false;
            response.Message = response.Message = AccountMessageConst.SignUpFailed;

            try
            {
                var  updateUserInfo = new AUser();

                if (request.UserDTO != null)
                {
                    updateUserInfo = _balUser.GetSelectedUser(request.UserDTO?.Sno ?? 0);

                    if ((!string.IsNullOrEmpty(updateUserInfo.Username) && !updateUserInfo.Username.Equals(request?.UserDTO?.Username))
                        || (request?.UserDTO?.Sno == 0 && !string.IsNullOrEmpty(request?.UserDTO?.Username)))
                    {

                        updateUserInfo = _balUser.UserNameSearch(updateUserInfo.Username);
                        if (updateUserInfo != null)
                        {
                            response.Message = AccountMessageConst.UserExist;
                            goto returnResponse;
                        }

                    }

                    if ((!string.IsNullOrEmpty(updateUserInfo?.MobileNumber) && !updateUserInfo.MobileNumber.Equals(request?.UserDTO?.MobileNumber))
                        || (request?.UserDTO?.Sno == 0 && !string.IsNullOrEmpty(request?.UserDTO?.MobileNumber)))
                    {
                        updateUserInfo = _balUser.GetUserByMobileNumber(request?.UserDTO?.MobileNumber);
                        if (updateUserInfo != null)
                        {
                            response.Message = AccountMessageConst.MobileNumberExist;
                            goto returnResponse;
                        }
                    }

                    updateUserInfo!.Active = request?.UserDTO?.Active ?? true;
                    updateUserInfo.Adminuser = request?.UserDTO?.AdminUser ?? false;
                    updateUserInfo.CanAdd = request?.UserDTO?.CanAdd ?? false;
                    updateUserInfo.CanEdit = request?.UserDTO?.CanEdit ?? false;
                    updateUserInfo.CanReport = request?.UserDTO?.CanReport ?? false;
                    updateUserInfo.Password = request?.UserDTO?.HashedPassword ?? updateUserInfo.Password;
                    updateUserInfo.Username = request?.UserDTO?.Username ?? updateUserInfo.Username;
                    updateUserInfo.MobileNumber = request?.UserDTO?.MobileNumber ?? updateUserInfo.MobileNumber;
                    updateUserInfo.Role = request?.UserDTO?.Role.ToString() ?? UserRole.Guest.ToString();


                    if (updateUserInfo.Sno > 0)
                    {
                        _balUser.UpdateUser(updateUserInfo);

                    }
                    else
                    {
                        _balUser.AddUser(updateUserInfo);
                    }

                    response.Data = updateUserInfo.Sno;
                    response.Success = true;
                    response.Message = AccountMessageConst.SignUpSuccessful;
                }
            }
            catch
            {
                response.Success = false;
                response.Message = ApiMessageConst.ServerError;
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
