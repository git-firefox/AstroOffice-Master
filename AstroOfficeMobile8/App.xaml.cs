using AstroOfficeMobile8.Account;
using AstroOfficeMobile8.Pages;
using AstroOfficeMobile8.Services.IServices;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace AstroOfficeMobile8
{
    public partial class App : Application
    {
        public App(IAccountService accountService)
        {
            InitializeComponent();

            //MainPage = new AppShell();   
            MainPage = new Dashboard("");

            //var loginPage = new LoginPage(accountService);
            //NavigationPage.SetHasNavigationBar(loginPage, false);
            //MainPage = new NavigationPage(loginPage);
        }
    }
}
