using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Shared.Models;
using AstroShared.DTOs;
using AstroShared.Helper;
using AstroShared.ViewModels;
using Microsoft.JSInterop;

namespace AstroOfficeWeb.Client.Services
{
    public class TokenWalletService
    {
        private readonly ISwaggerApiService _swagger;
        private readonly IJSRuntime _jsRuntime;

        public TokenWalletService(ISwaggerApiService swagger, IJSRuntime jsRuntime)
        {
            _swagger = swagger;
            _jsRuntime = jsRuntime;
        }

        public async Task<decimal> GetBalance()
        {
            var response = await _swagger!.GetAsync<ApiResponse<decimal>>(TokenWalletApiConst.GET_Balance);
            return response?.Data ?? 0;
        }

        public async Task<List<TokenRechargeTableTRModel>?> GetTokenRechargeTransactionHistory()
        {
            var response = await _swagger!.GetAsync<List<PaymentInfoDto>>(TokenWalletApiConst.GET_TokenRechargeTransactionHistory);
            var temp = response?.Select((a, index) => new TokenRechargeTableTRModel
            {
                SrNo = index + 1,
                Status = a.StatusName,
                PaymentAmount = a.Amount,
                PaymentDate = a.PaymentDate,
                TimestampCreated = a.TimestampCreated,
            }).ToList();
            return temp;
        }

        public async Task<List<TransactionTableTRModel>?> GetTokenTransactionHistory()
        {
            var response = await _swagger!.GetAsync<List<TokenTransactionDTO>>(TokenWalletApiConst.GET_TokenTransactionHistory);
            var temp = response?.Select((a, index) => new TransactionTableTRModel
            {
                Amount = a.Amount,
                Description = a.Description,
                SrNo = index + 1,
                TimestampCreated = a.TimestampCreated,
                TransactionType = a.StatusType,
                Action = a.Action
            }).ToList();
            return temp ?? new List<TransactionTableTRModel>();
        }

        public async Task<decimal> UpdateTokenBalance(TransactionType type, decimal amount, string description, string action, string actionDescription)
        {
            var request = new UpdateTokenBalanceRequest()
            {
                TransactionType = type,
                Amount = amount,
                Description = actionDescription,
                Action = action,
                PaymentDate = DateTime.Now
            };
            var response = await _swagger!.PostAsync<UpdateTokenBalanceRequest, ApiResponse<decimal>>(TokenWalletApiConst.POST_UpdateTokenBalance, request);
            if (response!.Success)
            {
                await _jsRuntime.ShowToastAsync(description);
            }
            else
            {
                await _jsRuntime.ShowToastAsync(response!.ErrorMessage, SwalIcon.Error);
            }

            return response!.Data;
        }

        public async Task<decimal> UpdateRechargeTokenBalance(TransactionType type, decimal amount, string description)
        {
            var request = new UpdateTokenBalanceRequest()
            {
                TransactionType = type,
                Amount = amount,
                Description = description,
                PaymentDate = DateTime.Now
            };

            var response = await _swagger!.PostAsync<UpdateTokenBalanceRequest, ApiResponse<decimal>>(TokenWalletApiConst.POST_UpdateRechargeTokenBalance, request);

            if (response!.Success)
            {
                await _jsRuntime.ShowToastAsync(description);
            }
            else
            {
                await _jsRuntime.ShowToastAsync(response!.ErrorMessage, SwalIcon.Error);
            }

            return response!.Data;
        }
    }
}
