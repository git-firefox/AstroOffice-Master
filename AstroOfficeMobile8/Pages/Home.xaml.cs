namespace AstroOfficeMobile8.Pages;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();

        BindingContext = new SavedKundali();
        //ToolbarItem item = new ToolbarItem
        //{
        //    Text = "Add item",
        //    IconImageSource = ImageSource.FromFile("ellipsis.png")
        //};
        //this.ToolbarItems.Add(item);
    }



    private void AddItem_Clicked(object sender, EventArgs e)
    {

    }

    private void EditItem_Clicked(object sender, EventArgs e)
    {

    }

    private void DeleteItem_Clicked(object sender, EventArgs e)
    {

    }

    private void OnItemClicked(object sender, EventArgs e)
    {
        ToolbarItem item = (ToolbarItem)sender;
        //messageLabel.Text = $"You clicked the \"{item.Text}\" toolbar item.";
    }
}