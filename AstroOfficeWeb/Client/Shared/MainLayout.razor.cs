using MudBlazor;

namespace AstroOfficeWeb.Client.Shared
{

    public partial class MainLayout
    {
        private MudTheme AppTheme { get; set; } = null!;
        protected override void OnInitialized()
        {
            AppTheme = new MudTheme()
            {
                Palette = new PaletteLight()
                {
                    Primary = new MudBlazor.Utilities.MudColor("#ff8808"),
                },

                Typography = new Typography()
                {
                    Default = new Default()
                    {
                        FontFamily = new string[] { "Philosopher", "sans-serif" }
                    }
                }
            };
        }
    }
}
