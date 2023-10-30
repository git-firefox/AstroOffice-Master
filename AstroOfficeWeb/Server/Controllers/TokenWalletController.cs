using ASModels;
using AstroOfficeWeb.Server.Helper;
using AstroOfficeWeb.Shared.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TokenWalletController : ControllerBase
    {
        private readonly AstrooffContext _context;
        private readonly IMapper _mapper;

        public TokenWalletController(AstrooffContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBalance()
        {
            var tokenBalance = await _context.AUserTokenBalances.FirstAsync(a => a.AUserSno == User.GetUserSno());
            return Ok(new ApiResponse<decimal?> { Data = tokenBalance.TokenBalance, Success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetTokenRechargeTransactionHistory()
        {
            var transactions = await _context.ACcavenueTransactions.Where(a => a.AUserSno == User.GetUserSno()).ToListAsync();
            var statuses = await _context.ATransactionStatuses.ToListAsync();

            var temp = transactions.Join(statuses,
                t => t.ATransactionStatusesId,
                s => s.Id,
                (t, s) => new
                {

                });
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetTokenTransactionHistory()
        {
            var transactions = await _context.ATokenTransactions.Where(a => a.AUserSno == User.GetUserSno()).ToListAsync();
            return Ok();
        }

        [HttpGet]
        public IActionResult UpdateTokenBalance(int token)
        {
            return Ok();
        }
    }
}
