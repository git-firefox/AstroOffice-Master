using ASModels;
using AstroOfficeWeb.Server.Helper;

using AstroOfficeWeb.Shared.Models;
using AstroShared.DTOs;
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
                (t, s) => new PaymentInfoDto
                {
                    CcavenueResponse = t.CcavenueResponse,
                    PaymentDate = t.PaymentDate,
                    TimestampCreated = t.TimestampCreated,
                    StatusName = s.StatusName,
                    Amount = t.PaymentAmount
                }).OrderByDescending(o => o.TimestampCreated);
            return Ok(temp);
        }

        [HttpGet]
        public async Task<IActionResult> GetTokenTransactionHistory()
        {
            var transactions = await _context.ATokenTransactions.Where(a => a.AUserSno == User.GetUserSno()).ToListAsync();
            var statuses = await _context.ATransactionStatuses.ToListAsync();

            var temp = transactions.Join(statuses,
                t => t.ATransactionStatusesId,
                s => s.Id,
                (t, s) => new TokenTransactionDTO
                {
                    TimestampCreated = t.TimestampCreated,
                    Amount = t.Amount,
                    Action = t.Action,
                    Description = t.Description,
                    StatusType = s.StatusName
                }).OrderByDescending(o => o.TimestampCreated); ;
            return Ok(temp);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTokenBalance(UpdateTokenBalanceRequest request)
        {
            var aUserToken = await _context.AUserTokenBalances.FirstAsync(a => a.AUserSno == User.GetUserSno());

            var response = new ApiResponse<decimal?>();
            response.Success = false;
            response.ErrorMessage = ApiMessageConst.ServerError;
            response.Data = aUserToken.TokenBalance;


            if (aUserToken.TokenBalance == 0)
            {
                response.Success = false;
                response.ErrorMessage = TokenWalletMessageConst.BalanceZeroMessage;
                goto returnResponse;
            }

            if (request.TransactionType == TransactionType.Purchase)
            {
                if (request.Amount > aUserToken.TokenBalance)
                {
                    response.Success = false;
                    response.ErrorMessage = TokenWalletMessageConst.InsufficientBalance;
                    goto returnResponse;
                }

                aUserToken.TokenBalance -= request.Amount;

                var entity = new ASModels.Astrooff.ATokenTransaction
                {
                    TransactionType = TransactionType.Purchase.ToString(),
                    Description = request.Description,
                    Amount = request.Amount,
                    TimestampCreated = request.PaymentDate,
                    Action = request.Action,
                    AUserSno = User.GetUserSno(),
                    ATransactionStatusesId = Convert.ToInt32(TransactionStatus.Success),
                };

                await _context.ATokenTransactions.AddAsync(entity);

                await _context.SaveChangesAsync();

                response.Data = aUserToken.TokenBalance;
                response.Success = true;
                response.ErrorMessage = TokenWalletMessageConst.TokenBalanceUpdated;
            }

            returnResponse:
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRechargeTokenBalance(UpdateTokenBalanceRequest request)
        {
            var aUserToken = await _context.AUserTokenBalances.FirstAsync(a => a.AUserSno == User.GetUserSno());

            var response = new ApiResponse<decimal?>();
            response.Success = false;
            response.ErrorMessage = ApiMessageConst.ServerError;
            response.Data = aUserToken.TokenBalance;


            if (request.Amount == 0)
            {
                response.Success = false;
                response.ErrorMessage = TokenWalletMessageConst.ErrorBalanceZeroMessage;
                goto returnResponse;
            }

            if (request.TransactionType == TransactionType.Deposit)
            {
                aUserToken.TokenBalance += request.Amount;

                var entity = new ASModels.Astrooff.ACcavenueTransaction
                {
                    PaymentAmount = request.Amount,
                    PaymentDate = request.PaymentDate,
                    TimestampCreated = DateTime.Now,
                    AUserSno = User.GetUserSno(),
                    ATransactionStatusesId = Convert.ToInt32(TransactionStatus.Success),
                    CcavenueResponse = request.Description,
                };

                await _context.ACcavenueTransactions.AddAsync(entity);

                await _context.SaveChangesAsync();

                response.Data = aUserToken.TokenBalance;
                response.Success = true;
                response.ErrorMessage = TokenWalletMessageConst.TokenRecharge;
            }

            returnResponse:
            return Ok(response);
        }
    }
}
