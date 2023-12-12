using AstroOfficeMobile8.Account;

namespace AstroOfficeMobile8.Pages;

public partial class Dashboard : Shell
{

    private readonly string _userName;
    public Dashboard(string userName)
	{
		InitializeComponent();
        _userName = userName;
        //WelcomeLabel.Text = $"Welcome, {_userName}!";

        Routing.RegisterRoute("login", typeof(LoginPage));

    }
}