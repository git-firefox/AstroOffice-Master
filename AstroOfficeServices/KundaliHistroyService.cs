using AstroOfficeWeb.Shared.Models;
using AstroShared.DTOs;
using AstroShared.Helper;
using AstroShared.ViewModels;
using AstroShared;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeServices.IServices;

namespace AstroOfficeServices
{
    public class KundaliHistroyService
    {
        private readonly ISwaggerApiService _swagger;
        private readonly IJSRuntime _jsRuntime;
        public BirthDetails? SelectedSavedKundali;

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
                ProductName = bd.CmbCategory,
                CheckSahasaneLogic = bd.ChkSahasaneLogic,
                CheckSalaChakkar = bd.SalaChakkar,
                DateOfBirth = new DateTime(bd.Dobyy, bd.Dobmm, bd.Dobdd),
                TimeOfBirth = new TimeSpan(bd.Tobhh, bd.Tobmm, bd.Tobss),
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
                TimeValue = bd.TimeValue,
                PlaceOfBrithSearch = bd.TxtBirthPlace[..3].ToString()
            };

            var response = await _swagger!.PostAsync<SaveKundaliRequest, ApiResponse<string>>(KundaliHistoryApiConst.POST_SaveKundali, request);
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
                ProductName = bd.CmbCategory,
                CheckSahasaneLogic = bd.ChkSahasaneLogic,
                CheckSalaChakkar = bd.SalaChakkar,
                DateOfBirth = new DateTime(bd.Dobyy, bd.Dobmm, bd.Dobdd),
                TimeOfBirth = new TimeSpan(bd.Tobhh, bd.Tobmm, bd.Tobss),
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
                TimeValue = bd.TimeValue,
                PlaceOfBrithSearch = bd.TxtBirthPlace[..3].ToString()
            };

            var response = await _swagger!.PostAsync<SaveKundaliRequest, ApiResponse<string>>(KundaliHistoryApiConst.POST_SaveKundali, request);
            await _jsRuntime.ShowToastAsync("Kundali Saved!");
        }

        public async Task<List<PersonKundaliTableTRModel>?> GetUserViewedKundalies()
        {
            var response = await _swagger!.GetAsync<List<KundaliDTO>>(KundaliHistoryApiConst.GET_GetAllUserKundalies);
            var temp = response?.Where(r => !r.IsSaved).Select((r, index) => new PersonKundaliTableTRModel
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

        public static List<KundaliDTO>? SavedKundalies;
        public async Task<List<PersonKundaliTableTRModel>?> GetUserSavedKundalies()
        {
            SelectedSavedKundali = null;

            var response = await _swagger!.GetAsync<List<KundaliDTO>>(KundaliHistoryApiConst.GET_GetAllUserKundalies);

            SavedKundalies = response?.Where(r => r.IsSaved).ToList();

            var temp = SavedKundalies?.Select((r, index) => new PersonKundaliTableTRModel
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
        public void SetSelectedSavedKundali(int selectedIndex)
        {
            SelectedSavedKundali = null;

            if (SavedKundalies?.Count == 0)
            {
                SelectedSavedKundali = null;
                return;
            }

            var kundali = SavedKundalies?[selectedIndex];

            if (kundali == null)
            {
                SelectedSavedKundali = null;
                return;
            }

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            SelectedSavedKundali = new BirthDetails
            {
                CmbCountry = kundali.CountryCode ?? "Ind.",
                TxtName = kundali.Name ?? "SIVA",
                CmbTime = textInfo.ToTitleCase(kundali.TimeType ?? "minute"),
                TimeValue = kundali.TimeValue,
                Dobdd = kundali.DateOfBirth.Day,
                Dobmm = kundali.DateOfBirth.Month,
                Dobyy = kundali.DateOfBirth.Year,
                Tobhh = kundali.TimeOfBirth.Hours,
                Tobmm = kundali.TimeOfBirth.Minutes,
                Tobss = kundali.TimeOfBirth.Seconds,
                TxtBirthPlace = kundali.PlaceOfBrithSearch?.ToLower() ?? "Delhi",
                //BirthPlace = "Delhi",
                //BirthCity = string.Empty,
                //IsMale = false,
                //IsFemale = false,
                CmbCategory = kundali.Category ?? "Kamkaj",
                CmbAyanansh = kundali.Ayanansh ?? "KP",
                //Brief = string.Empty,
                CmbRotate = kundali.Rotate,
                ChkSahasaneLogic = kundali.CheckSahasaneLogic, // Set to true or false as needed
                SalaChakkar = kundali.CheckSalaChakkar,
                ChkMfal = kundali.CheckMFal,
                CmbLanguage = kundali.Language ?? "Hindi",
                ChkShowRef = kundali.CheckShowRef,
                Gender = Enum.Parse<Gender>(kundali.Gender ?? "Male"),
                KundaliUdvYear = kundali.KundaliUdvYear,
                PlaceOfBirthID = kundali.PlaceOfBirthID,
                CmbSkipBad = kundali.SkipBadType
            };

        }

        public async Task<bool> IsDeletedSavedKundali(int? id)
        {
            var response = await _swagger!.DeleteAsync<ApiResponse<string>>(KundaliHistoryApiConst.DELETE_DeleteSavedKundali, queryParams: new Dictionary<string, string>
            {
                { "id", id.ToString() ?? "" }
            });

            if (response!.Success)
            {
                await _jsRuntime.ShowToastAsync(response.Message);
                return true;
            }
            else
            {
                await _jsRuntime.ShowToastAsync(response.Message, SwalIcon.Error);
                return false;
            }
        }
    }
}
