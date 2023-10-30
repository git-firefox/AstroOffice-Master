using AstroOfficeWeb.Client.Helper;
using AstroOfficeWeb.Client.Models;
using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Models;
using Microsoft.JSInterop;

namespace AstroOfficeWeb.Client.Services
{
    public class KundaliHistroyService
    {
        private readonly ISwaggerApiService _swagger;
        private readonly IJSRuntime _jsRuntime;

        public KundaliHistroyService(ISwaggerApiService swagger, IJSRuntime jsRuntime)
        {
            _swagger = swagger;
            _jsRuntime = jsRuntime;
        }

        public async Task SaveKundaliLog(BirthDetails bd)
        {
            var request = new SaveKundaliRequest()
            {
                Ayanansh = bd.CmbAyanansh,
                Category = bd.CmbCategory,
                CheckMFal = bd.ChkMfal,
                CountryCode = bd.CmbCountry,
                Name = bd.TxtName,
                ProductName = null,
                CheckSahasaneLogic = bd.ChkSahasaneLogic,
                CheckSalaChakkar = bd.SalaChakkar,
                DateOfBirth = new DateTime(bd.Dobyy, bd.Dobmm, bd.Dobdd),
                TimeOfBirth = new TimeSpan(bd.Tobhh, bd.Tobhh, bd.Tobss),
                CheckShowRef = bd.ChkShowRef,
                Gender = bd.Gender.ToString(),
                IsPaid = false,
                IsSaved = false,
                KundaliUdvYear = bd.KundaliUdvYear,
                Language = bd.CmbLanguage,
                PlaceOfBirthID = bd.PlaceOfBirthID,
                Rotate = bd.CmbRotate,
                SkipBadType = bd.CmbSkipBad,
                TimeType = bd.CmbTime,
            };

            var response = await _swagger!.PostAsync<SaveKundaliRequest, ApiResponse<string>>(KundaliHistoryApiConst.POST_SaveKundali, request);
            await _jsRuntime.ShowToastAsync(response?.Message);
        }

        public async Task SaveKundali(BirthDetails bd)
        {
            var request = new SaveKundaliRequest()
            {
                Ayanansh = bd.CmbAyanansh,
                Category = bd.CmbCategory,
                CheckMFal = bd.ChkMfal,
                CountryCode = bd.CmbCountry,
                Name = bd.TxtName,
                ProductName = null,
                CheckSahasaneLogic = bd.ChkSahasaneLogic,
                CheckSalaChakkar = bd.SalaChakkar,
                DateOfBirth = new DateTime(bd.Dobyy, bd.Dobmm, bd.Dobdd),
                TimeOfBirth = new TimeSpan(bd.Tobhh, bd.Tobhh, bd.Tobss),
                CheckShowRef = bd.ChkShowRef,
                Gender = bd.Gender.ToString(),
                IsPaid = false,
                IsSaved = true,
                KundaliUdvYear = bd.KundaliUdvYear,
                Language = bd.CmbLanguage,
                PlaceOfBirthID = bd.PlaceOfBirthID,
                Rotate = bd.CmbRotate,
                SkipBadType = bd.CmbSkipBad,
                TimeType = bd.CmbTime,
            };

            var response = await _swagger!.PostAsync<SaveKundaliRequest, ApiResponse<string>>(KundaliHistoryApiConst.POST_SaveKundali, request);
            await _jsRuntime.ShowToastAsync(response?.Message);
        }

        public async Task<List<PersonKundaliTableTRModel>?> GetUserViewedKundalies()
        {
            var response = await _swagger!.GetAsync<List<KundaliDTO>>(KundaliHistoryApiConst.GET_GetAllUserKundalies);
            var temp = response?.Select((r, index) => new PersonKundaliTableTRModel
            {
                SrNo = index + 1,
                ID = r.ID,
                Name = r.Name,
                Gender = r.Gender,
                ViewDate = r.ViewDate,
                DateOfBirth = r.DateOfBirth,
                TimeOfBirth = r.TimeOfBirth,
                PlaceOfBirth = r.PlaceOfBirth ?? "",
                ProductName = r.Category,
                Language = r.Language
            }).ToList();
            return temp;
        }

        public async Task<List<PersonKundaliTableTRModel>?> GetUserSavedKundalies()
        {
            var response = await _swagger!.GetAsync<List<KundaliDTO>>(KundaliHistoryApiConst.GET_GetAllUserKundalies);

            var temp = response?.Where(r => r.IsSaved).Select((r, index) => new PersonKundaliTableTRModel
            {
                SrNo = index + 1,
                ID = r.ID,
                Name = r.Name,
                Gender = r.Gender,
                ViewDate = r.ViewDate,
                DateOfBirth = r.DateOfBirth,
                TimeOfBirth = r.TimeOfBirth,
                PlaceOfBirth = r.PlaceOfBirth ?? "",
                ProductName = r.Category,
                Language = r.Language
            }).ToList();
            return temp;
        }
    }
}
