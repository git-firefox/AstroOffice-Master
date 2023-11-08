using AstroShared.Helper;
using AstroShared.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeMobile.Shared;
using AstroShared.DTOs;
using AstroOfficeMobile.Services;
using AstroShared;

namespace AstroOfficeMobile.Pages
{
    public partial class Dashboard
    {
        [CascadingParameter]
        private MainLayout MainLayout { get; set; }
        public List<SelectListItem> CmbCountry { get; set; }= new List<SelectListItem>();
        private List<PlaceDTO> ListBirthCities = new();

        private BirthDetails BirthDetails { get; set; } = new BirthDetails();
        protected override void OnInitialized()
        {
            MainLayout.NavTitle = "Edit Kundali";
        }
        protected override async Task OnInitializedAsync()
        {
            var countryMasters = await GetCountry();
            CmbCountry = countryMasters?.Select(cm => new SelectListItem(cm.Country, cm.CountryCode)).ToList();

            if ( this.BirthDetails.CmbCountry != null)
            {
                this.ListBirthCities = await this.GetPlaceListLike(place: BirthDetails?.TxtBirthPlace?.Trim(), countrycode: this.BirthDetails?.CmbCountry);

            }
            if (KundaliHistroy.SelectedSavedKundali != null)
            {
                BirthDetails = KundaliHistroy.SelectedSavedKundali;
            }
            await MainLayout.NotifyChangeAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.CloseSidebar();
            }
        }

        private async Task<List<CountryDTO>> GetCountry()
        {
            var countryMasters = await Swagger!.GetAsync<List<CountryDTO>>(CountryApiConst.GET_GetCountry);
            return countryMasters;
        }


        private async Task<List<PlaceDTO>> GetPlaceListLike(string place, string countrycode)
        {
            var response = await Swagger!.GetAsync<List<PlaceDTO>>(string.Format(LocationBLLApiConst.GET_GetPlaceListLike, place, countrycode));
            return response;
        }
    }
}
