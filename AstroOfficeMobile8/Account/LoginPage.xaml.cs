namespace AstroOfficeMobile8.Account;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void OnLoginClicked(object sender, EventArgs e)
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
            Navigation.PushAsync(new MainPage());

        }
    }
}