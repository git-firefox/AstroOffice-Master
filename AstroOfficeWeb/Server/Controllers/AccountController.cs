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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]")]
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

        // GET api/<UserController>/5
        [HttpPost(nameof(SignIn))]
        public IActionResult SignIn([FromBody] SignInRequest signInReques)
        {
            var response = new SignInResponse
            {
                IsAuthSuccessful = false,
                ErrorMessage = "Invalid Authentication"
            };

            if (signInReques == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var aUser = _balUser.UserLogin(signInReques!.UserName, signInReques!.Password);

            if (aUser.Sno <= 0)
            {
                return Unauthorized(response);
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
            response.ErrorMessage = "";

            return Ok(response);
        }

        [HttpGet("{userName}")]
        public IActionResult Get(string userName)
        {
            var aUser = _balUser.UserNameSearch(userName);

            return Ok(aUser);
        }

        [HttpGet("GetSelectedUser")]
        public IActionResult GetSelectedUser(long sno)
        {
            var aUser = _balUser.GetSelectedUser(sno);

            return Ok(aUser);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromForm] AUser au)
        {
            var aUSer = _balUser.UpdateUser(au);
            return Ok(aUSer);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var aUSer = _balUser.GetAllUsers();
            return Ok(aUSer);
        }

        [HttpPost(nameof(SignUp))]
        public IActionResult SignUp([FromBody] SignUpRequest signUpRequest)
        {
            var signUpResponse = new SignUpResponse();

            if (signUpRequest == null)
            {
                return BadRequest();
            }

            if (_balUser.GetAllUsers().Any(a => a.Username == signUpRequest.Name))
            {
                signUpResponse.Errors = new List<string>() { "UserName already exists." };
                return Ok(signUpResponse);
            }

            if (ModelState.IsValid)
            {
                var aUser = new AUser()
                {
                    Active = true,
                    Adminuser = false,
                    CanAdd = true,
                    CanEdit = true,
                    CanReport = true,
                    Password = signUpRequest.Password,
                    Username = signUpRequest.Name,
                };

                try
                {
                    _balUser.AddUser(aUser);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            var allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            signUpResponse.Errors = allErrors;

            return Ok(signUpResponse);
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
