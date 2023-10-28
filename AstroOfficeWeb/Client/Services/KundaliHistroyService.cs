using AstroOfficeWeb.Client.Helper;
using AstroOfficeWeb.Client.Models;
using AstroOfficeWeb.Client.Services.IService;
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

        public async Task SaveKundali(BirthDetails bd)
        {
            var request = new SaveKundaliRequest() {
                Ayanansh = bd.CmbAyanansh,
                Category = bd.CmbCategory,
                CheckMFal = bd.ChkMfal,
                CountryCode = bd.CmbCountry,
                Name = bd.TxtName,
                ProductName = null,
                CheckSahasaneLogic = bd.ChkSahasaneLogic,
                CheckSalaChakkar = bd.SalaChakkar,
                DateOfBirth = new DateOnly(bd.Dobyy, bd.Dobmm, bd.Dobdd),
                TimeOfBirth = new TimeOnly(bd.Tobhh, bd.Tobhh, bd.Tobss),
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
        }

        public async Task<List<PersonKundaliTableTRModel>> GetUserViewedKundalies()
        {
            var response = await _swagger!.GetAsync<SaveKundaliRequest>(KundaliHistoryApiConst.GET_GetAllUserKundalies);

            throw new NotImplementedException();
        }

        public async Task<List<PersonKundaliTableTRModel>> GetUserSavedKundalies()
        {

            var response = await _swagger!.GetAsync<SaveKundaliRequest>(KundaliHistoryApiConst.GET_GetAllUserKundalies);

            throw new NotImplementedException();
        }
    }
}
