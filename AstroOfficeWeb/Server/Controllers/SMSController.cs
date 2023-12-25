using System.Collections.Generic;
using System.Net;
using ASModels;
using AstroOfficeWeb.Server.Helper;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.SSExpertSystem;
using AstroOfficeWeb.Shared.SSExpertSystem.Models;
using AstroShared.Helper;
using AstroShared.Services.SSExpertSystem;
using AstroShared.Services.SSExpertSystem.Models;
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
        public readonly SMSSevice _smsSevice;
        public readonly TemplateSevice _templateSevice;
        public readonly AstrooffContext _context;
        public readonly IWebHostEnvironment _environment;

        public SMSController(IOptions<SSExpertSystemSettings> setting, AstrooffContext context, IWebHostEnvironment environment)
        {
            _setting = setting.Value;
            _smsSevice = new(setting.Value);
            _templateSevice = new(setting.Value);
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> SendOtp([FromQuery] string mobileNumber)
        {
            try
            {


                var user = await _context.AUsers.FirstOrDefaultAsync(a => a.MobileNumber == mobileNumber && a.Active == true);
                //var response = new ApiSSExpertSystemResponse<List<SendOtpResponse>>();
                var response = new ApiSSExpertSystemResponse();

                if (user == null)
                    return Ok(new ApiResponse<string> { Success = false, Message = "This mobile number is not registered." });

                string otp = OtpHelper.GenerateOtp();

                var templates = await _templateSevice.GetTemplates();

                string? message = (templates?.Data?.ToObject<List<TemplateResponse>>())?.FirstOrDefault(t => t.TemplateName == "Account Login")?.MessageTemplate;

                if (!_environment.IsDevelopment())
                {
                    var request = new SendOtpRequest()
                    {
                        MobileNumbers = mobileNumber,
                        SenderId = "DAASTR",
                        ClientId = _setting.ClientId,
                        ApiKey = _setting.APIKey,
                        Message = message?.Replace("{#var#}", otp),
                    };

                    response = await _smsSevice.SendSMS(request);
                    if (1 < response?.ErrorCode)
                    {
                        return Ok(new ApiResponse<string> { Success = false, Message = response.ErrorDescription + ": Please try again later or Contact support." });
                    }
                    else
                    {
                        var messageID = (response?.Data?.ToObject<List<SendOtpResponse>>())?.FirstOrDefault()?.MessageId;

                        var responseStatus = await _smsSevice.GetMessageStatus(messageID);

                        var messageResponse = (response?.Data?.ToObject<List<MessageStatusResponse>>())?.FirstOrDefault();

                        if (response?.ErrorCode == 0 && messageResponse?.Status == "DELIVRD")
                        {
                            user.MobileOtp = otp;
                            await _context.SaveChangesAsync();
                            return Ok(new ApiResponse<string> { Success = true, Message = "Otp has been sent to your mobile number." });
                        }
                        else
                        {
                            return Ok(new ApiResponse<string> { Success = false, Message = "An unexpected error occurred. Please try again later." });
                        }
                    }
                }
                else
                {
                    user.MobileOtp = otp;
                    await _context.SaveChangesAsync();
                    return Ok(new ApiResponse<string> { Success = true, Message = "Otp has been sent to your mobile number." });
                }
            }
            catch
            {
                return Ok(new ApiResponse<string> { Success = false, Message = ApiMessageConst.ServerError });
            }
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
                await _context.SaveChangesAsync();
            }
            else
            {
                response.Success = false;
                response.Message = "Invalid OTP. Verification failed.";
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetMessa([FromQuery] string messageID)
        {
            //var response = new ApiResponse<string>();

            var response = await _smsSevice.GetMessageStatus(messageID);

            return Ok(response);
        }
    }
}
