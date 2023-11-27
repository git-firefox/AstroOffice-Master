using System.Net.WebSockets;
using System.Security.Claims;
using ASModels;
using ASModels.Astrooff;
using AstroOfficeWeb.Server.Helper;
using AstroOfficeWeb.Shared.Models;
using AstroShared.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KundaliHistoryController : ControllerBase
    {
        private readonly AstrooffContext _context;
        private readonly IMapper _mapper;

        public KundaliHistoryController(AstrooffContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUsersKundalies()
        {
            var kundalis = _context.AKundalis;
            return Ok(kundalis);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUserKundalies()
        {
            var kundalis = await _context.AKundalis.Where(a => a.AUserSno == User.GetUserSno()).OrderByDescending(a => a.ViewDate).ToListAsync();
            var temp = _mapper.Map<List<KundaliDTO>>(kundalis);

            temp?.ForEach(k =>
            {
                var place = _context.APlaceMasters.FirstOrDefault(a => a.Sno == k.PlaceOfBirthID);
                if (place?.StateOrCountryCode == null || place?.StateOrCountryCode.Length == 0)
                {
                    var county = _context.ACountryMasters.FirstOrDefault(a => a.CountryCode == place!.CountryCode);
                    k.PlaceOfBirth = $"{place?.Place} [ {county?.Country} ]";

                }
                else
                {
                    var state = _context.AStateMasters.FirstOrDefault(a => a.StateCode == place!.StateOrCountryCode);
                    k.PlaceOfBirth = $"{place?.Place} [ {state?.StateName} ]";
                }
            });

            return Ok(temp);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveKundali([FromBody] SaveKundaliRequest request)
        {
            var kundali = _mapper.Map<AKundali>(request);
            if (kundali == null)
                return BadRequest();
            kundali.AUserSno = User.GetUserSno();
            kundali.ViewDate = DateTime.Now;
            await _context.AKundalis.AddAsync(kundali);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse<string>() { Data = "Kundali Saved!", ErrorNo = 0, Success = true });
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteSavedKundali(int id)
        {
            var response = new ApiResponse<string>();
            var userIDValue = User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            var aUserSno = Convert.ToInt64(userIDValue);
            try
            {
                var savedKundali = await _context.AKundalis.FirstAsync(a => a.Id == id && a.AUserSno == aUserSno);

                _context.AKundalis.Remove(savedKundali);
                var affectedRecords = await _context.SaveChangesAsync();
                if (affectedRecords > 0)
                {
                    response.Success = true;
                    response.Message = KundaliHistoryMessageConst.KundaliDeleted;
                }
                else
                {
                    response.Success = false;
                    response.Message = KundaliHistoryMessageConst.KundaliDeletedFailed;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _ = ex;
                response.Success = false;
                response.Message = KundaliHistoryMessageConst.KundaliDeletedFailed;
                return Ok(response);
            }
        }
    }
}
