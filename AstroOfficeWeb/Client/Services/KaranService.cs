using System.Security.Cryptography.X509Certificates;
using AstroShared.Helper;
using AstroShared.Models;
using AstroShared.ViewModels;
using Blazored.LocalStorage;

namespace AstroOfficeWeb.Client.Services
{
    public class KaranService
    {

        private readonly ILocalStorageService _localStorage;

        public KaranService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task SaveKPHouseMappingVOs(List<KPHouseMappingVO>? kpHouseMappingVOs)
        {
            await _localStorage.SetItemAsync(ApplicationConst.Local_KPHouseMappingVOs, kpHouseMappingVOs);
        }

        public async Task SaveStateModel(SavedStateModel savedState)
        {
            await _localStorage.SetItemAsync(ApplicationConst.Local_SavedStateModel, savedState);
        }

        public async Task<SavedStateModel> GetSavedStateModel()
        {
            var savedStateModel = await _localStorage.GetItemAsync<SavedStateModel>(ApplicationConst.Local_SavedStateModel);
            return savedStateModel;
        }

        public async Task SaveKPPlanetMappingVOs(List<KPPlanetMappingVO> kpPlanetMappingVOs)
        {
            await _localStorage.SetItemAsync(ApplicationConst.Local_KPPlanetMappingVOs, kpPlanetMappingVOs);
        }

        public async Task<List<KPHouseMappingVO>> GetKPHouseMappingVOs()
        {
            var houseMappingVOs = await _localStorage.GetItemAsync<List<KPHouseMappingVO>>(ApplicationConst.Local_KPHouseMappingVOs);
            return houseMappingVOs;
        }

        public async Task<List<KPPlanetMappingVO>> GetKPPlanetMappingVOs()
        {
            var planetMappingVOs = await _localStorage.GetItemAsync<List<KPPlanetMappingVO>>(ApplicationConst.Local_KPPlanetMappingVOs);
            return planetMappingVOs;
        }

        public async ValueTask<bool> HasKey(string key)
        {
            return await _localStorage.ContainKeyAsync(key);
        }
    }
}
