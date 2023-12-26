using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.ViewModels;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Services
{
    public class TokenWalletService
    {
        private readonly ISwaggerApiService _swagger;

        public TokenWalletService(ISwaggerApiService swagger)
        {
            _swagger = swagger;
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
                // // await _jsRuntime.ShowToastAsync(description);
            }
            else
            {
                // // await _jsRuntime.ShowToastAsync(response!.Message, SwalIcon.Error);
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
                // await _jsRuntime.ShowToastAsync(description);
            }
            else
            {
                // await _jsRuntime.ShowToastAsync(response!.Message, SwalIcon.Error);
            }

            return response!.Data;
        }
    }
}
