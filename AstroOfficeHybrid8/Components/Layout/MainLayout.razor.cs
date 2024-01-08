using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MudBlazor;
using MudBlazor.ThemeManager;

namespace AstroOfficeHybrid8.Components.Layout
{
    public partial class MainLayout
    {
        private bool IsDrawerOpen { get; set; } = false;
        private bool IsTemeManagerOpen { get; set; } = false;
        private MudTheme AppTheme { get; set; } = null!;
        private ThemeManagerTheme ThemeManagerTheme { get; set; } = new ThemeManagerTheme();

        protected override void OnInitialized()
        {
            AppTheme = new MudTheme()
            {
                Palette = new PaletteLight()
                {
                    Primary = new MudBlazor.Utilities.MudColor("#ff8808"),
                    Secondary = new MudBlazor.Utilities.MudColor("#ff8808"),
                    AppbarBackground = MudBlazor.Colors.Red.Default,
                },
                PaletteDark = new PaletteDark()
                {
                    Primary = MudBlazor.Colors.Blue.Lighten1
                },

                LayoutProperties = new LayoutProperties()
                {
                    DrawerWidthLeft = "260px",
                    DrawerWidthRight = "300px"
                },

                Typography = new Typography()
                {
                    Default = new Default()
                    {
                        FontFamily = ["Philosopher", "sans-serif"]
                    }
                }
            };

            StateHasChanged();
        }

        private void OnThemeChanged(ThemeManagerTheme value)
        {
            AppTheme = value.Theme;
            StateHasChanged();
        }

        private void OnOpenChangedThemeManager(bool value) =>  IsTemeManagerOpen = value;
    }
}
