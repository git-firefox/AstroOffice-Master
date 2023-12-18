using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace AstroOfficeMobile8.Pages;
public enum ToolbarItemEnum
{
    Basic,
    Charts,
    KP,
    Dasha,
    Report
}


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

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {

        //var toolbarItem = sender as ToolbarItem;
        var toolbarItem = (ToolbarItem)sender;
        Debug.WriteLine($"ToolbarItem_Clicked: {toolbarItem?.Text}");

        string tabItem = toolbarItem?.Text ?? string.Empty;

        if (Enum.TryParse<ToolbarItemEnum>(tabItem, out var selectedTab))
        {

            switch (selectedTab)
            {
                case ToolbarItemEnum.Basic:
                    Navigation.PushAsync(new BasicPage());
                    break;

                case ToolbarItemEnum.Charts:
                    Navigation.PushAsync(new BasicPage());
                    break;

                case ToolbarItemEnum.KP:                    
                    Navigation.PushAsync(new BasicPage());
                    break;

                case ToolbarItemEnum.Dasha:                    
                    Navigation.PushAsync(new BasicPage());
                    break;

                case ToolbarItemEnum.Report:
                    
                    Navigation.PushAsync(new BasicPage());
                    break;

                default: break;

            }
        }
    }





}