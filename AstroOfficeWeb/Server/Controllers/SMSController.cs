using System.Net;
using ASModels;
using AstroOfficeWeb.Server.Helper;
using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        public readonly SSExpertSystemSettings _setting;
        public readonly HttpClientHelper _httpClient;
        public readonly AstrooffContext _context;

        public SMSController(IOptions<SSExpertSystemSettings> setting, AstrooffContext context)
        {
            _setting = setting.Value;
            _httpClient = new HttpClientHelper(_setting.BaseUrl);
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> SendOtp([FromQuery] string mobileNumber)
        {
            var user = await _context.AUsers.FirstOrDefaultAsync(a => a.MobileNumber == mobileNumber && a.Active == true);

            if (user == null)
                return Ok(new ApiResponse<string> { Success = false, Message = "This mobile number is not registered." });

            string otp = OtpHelper.GenerateOtp();

            var request = new SendOtpRequest()
            {
                MobileNumbers = mobileNumber,
                SenderId = "DAASTR",
                ClientId = _setting.ClientId,
                ApiKey = _setting.APIKey,
                Message = $"Divya Astro Ashram welcomes you. Please enter the OTP code {otp} in the space provided to log into your account.",
            };

            var response = await _httpClient.PostAsync<SendOtpRequest, ApiSSExpertSystemResponse<List<SendOtpResponse>>>(SMSApiConst.POST_SendSMS, request);

            if (response == null)
            {
                return Ok(new ApiResponse<string> { Success = false, Message = "An unexpected error occurred. Please try again later." });
            }

            if (response.ErrorCode == 0)
            {
                user.MobileOtp = otp;
                await _context.SaveChangesAsync();
            }

            return Ok(new ApiResponse<string> { Success = true, Message = "Otp has been to your mobile number." });
        }

        [HttpGet]
        public async Task<IActionResult> VerifyOtp([FromQuery] string mobileNumber, [FromQuery] string otp)
        {
            var response = new ApiResponse<string>();

            var user = await _context.AUsers.FirstOrDefaultAsync(a => a.MobileNumber == mobileNumber && a.Active == true);

            if (user == null)
            {
                return NotFound();
            }
            if (user?.MobileOtp == otp)
            {
                response.Success = true;
                response.Message = "OTP has been successfully verified.";
                //user.MobileOtp = null;
                //await _context.SaveChangesAsync();
            }
            else
            {
                response.Success = false;
                response.Message = "Invalid OTP. Verification failed.";
            }

            return Ok(response);
        }
    }
}
