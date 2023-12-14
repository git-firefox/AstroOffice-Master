namespace AstroOfficeMobile8.Pages;

public partial class Kundali : ContentPage
{

    public Kundali()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Add the CustomeShell when the Kundali page appears
        var customeShell = new CustomeShell();
        NavigationPage.SetHasNavigationBar(customeShell, true); // Optional: Hide navigation bar
        Navigation.PushAsync(customeShell);
    }
}