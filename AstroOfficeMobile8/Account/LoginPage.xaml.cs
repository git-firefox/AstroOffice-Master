using AstroOfficeMobile8.Pages;
using AstroOfficeMobile8.Services;
using AstroOfficeMobile8.Services.IServices;

namespace AstroOfficeMobile8.Account;

public partial class LoginPage : ContentPage
{
    private IAccountService? _accountService;

    public LoginPage()
    {
        InitializeComponent();
        _accountService = new AccountService();
    }
    //public LoginPage(IAccountService accountService)
    //{
    //  InitializeComponent();
    //    _accountService = accountService;
    //}

    private async void OnLoginClicked(object sender, EventArgs e)
    {


        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        // Perform your login logic here
        // For simplicity, let's just show an error message if both fields are empty
        if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
        {
            ErrorMessageLabel.Text = "Please enter both username and password.";
        }

        if (string.IsNullOrWhiteSpace(username))
        {
            ErrorMessageLabel.Text = "Please enter a username.";
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            ErrorMessageLabel.Text = "Please enter a password.";
            return;
        }
        else
        {
            var response = await _accountService.LoginAsync(new AstroOfficeWeb.Shared.Models.SignInRequest
            {
                UserName = username,
                Password = password
            });

            if (response.IsAuthSuccessful)
            {
                //await Navigation.PushAsync(new MainPage(UsernameEntry.Text));  
                await Navigation.PushAsync(new Home());
            }
            else
            {
                ErrorMessageLabel.Text = response.Message;
            }

        }
    }

}