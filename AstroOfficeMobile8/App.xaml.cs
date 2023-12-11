using AstroOfficeMobile8.Account;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace AstroOfficeMobile8
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();

            var loginPage = new LoginPage();
            NavigationPage.SetHasNavigationBar(loginPage, false);
            MainPage = new NavigationPage(loginPage);

        }
    }
}
