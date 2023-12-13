namespace AstroOfficeMobile8.Pages;

public partial class Kundali : ContentPage
{



    public Kundali()
    {
        InitializeComponent();
        if (SavedKundali.SelectedFruit?.FruitName != null)
        {
            labels.Text = SavedKundali.SelectedFruit.FruitName;
        }
    }
}