using AstroOfficeMobile8.Account;

namespace AstroOfficeMobile8
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private readonly string _userName;

        public MainPage(string userName)
        {
            InitializeComponent();
            _userName = userName;

            // Set the WelcomeLabel text when the page is created
            WelcomeLabel.Text = $"Welcome, {_userName}!";
        }


        // Call this method when the user logs in
      

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
