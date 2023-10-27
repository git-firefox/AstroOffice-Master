using System.Net.WebSockets;
using System.Security.Claims;
using ASModels;
using ASModels.Astrooff;
using AstroOfficeWeb.Shared.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllUserKundalies()
        {
            var userIDValue = User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            var aUserSno = Convert.ToInt64(userIDValue);
            var kundalis = _context.AKundalis.Where(a => a.AUserSno == aUserSno);
            return Ok(kundalis);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveKundali([FromBody] SaveKundaliRequest request)
        {
            var userIDValue = User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            var aUserSno = Convert.ToInt64(userIDValue);
            var kundali = _mapper.Map<AKundali>(request);
            if (kundali == null)
                return BadRequest();
            kundali.AUserSno = aUserSno;
            await _context.AKundalis.AddAsync(kundali);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse<string>() { Data = "Kundali Saved!", ErrorNo = 0, Success = true });
        }
    }
}
