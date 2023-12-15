
namespace AstroOfficeMobile8.Pages;

public partial class EditKundali : ContentPage
{
    

    public EditKundali()
	{
		InitializeComponent();
        //editFruitName.Text = SavedKundali.SelectedFruit?.FruitName;
        //editFruitDescription.Text = SavedKundali.SelectedFruit?.FruitDescription;
        //editImageSource.Text = SavedKundali.SelectedFruit?.ImageSource;

    }
    private void SaveChangesButton_Clicked(object sender, EventArgs e)
    {
        //editFruitName.Text = SavedKundali.SelectedFruit.FruitName;
        //editFruitDescription.Text = SavedKundali.SelectedFruit.FruitDescription;
        //editImageSource.Text = SavedKundali.SelectedFruit.ImageSource;

        if (SavedKundali.SelectedFruit != null)
        {
            //SavedKundali.SelectedFruit.FruitName = editFruitName.Text;
            //SavedKundali.SelectedFruit.FruitDescription = editFruitDescription.Text;
            //SavedKundali.SelectedFruit.ImageSource = editImageSource.Text;
        }
        
    }

    private void LocationLabel_Tapped(object sender, TappedEventArgs e)
    {
        
        Navigation.PushAsync(new PlaceOfBirth());
    }
}