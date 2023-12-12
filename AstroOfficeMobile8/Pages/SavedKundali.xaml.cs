using System.Collections.ObjectModel;

namespace AstroOfficeMobile8.Pages;



public partial class SavedKundali : ContentPage
{
    public class Fruit
    {
        public string? FruitName { get; set; }
    }

    ObservableCollection<Fruit> fruits = new ();
    public ObservableCollection<Fruit> Fruits { get { return fruits; } }
    public SavedKundali()
	{
		InitializeComponent();
        fruits.Add(new Fruit() { FruitName = "Apple" });
        fruits.Add(new Fruit() { FruitName = "Orange" });
        fruits.Add(new Fruit() { FruitName = "Banana" });
        fruits.Add(new Fruit() { FruitName = "Grape" });
        fruits.Add(new Fruit() { FruitName = "Mango" });
        FruitListView.ItemsSource = fruits;
    }
}