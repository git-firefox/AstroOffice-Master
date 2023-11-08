using AstroShared.Methods;
using AstroShared.Models;
using AstroShared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeMobile.Shared;
using AstroShared.Helper;

namespace AstroOfficeMobile.Pages
{
    public partial class Kundali
    {

        private bool isNumVarshVisible = true;
        private BirthDetails BirthDetails  { get; set; }

        [CascadingParameter]
        private MainLayout MainLayout { get; set; }

        protected override void OnInitialized()
        {

            if (KundaliHistroy.SelectedSavedKundali != null)
            {
                BirthDetails = KundaliHistroy.SelectedSavedKundali;
            }
            MainLayout.NavTitle = "Kundali";
        }

        protected override async Task OnInitializedAsync()
        {
            await MainLayout.NotifyChangeAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.CloseSidebar();
            }
        }
    }
}
