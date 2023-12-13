using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using System.Threading;

namespace AstroOfficeMobile8.Pages;



public partial class SavedKundali : ContentPage
{
    public class Fruit
    {
        public string? FruitName { get; set; }
        public string? FruitDescription { get; set; }
        public string? ImageSource { get; set; }
    }

    ObservableCollection<Fruit> fruits = new();
    public ObservableCollection<Fruit> Fruits { get { return fruits; } }
    public static Fruit? SelectedFruit { get; private set; }
    public SavedKundali()
    {
        InitializeComponent();
        //fruits.Add(new Fruit() { FruitName = "Apple" });
        //fruits.Add(new Fruit() { FruitName = "Orange" });
        //fruits.Add(new Fruit() { FruitName = "Banana" });
        //fruits.Add(new Fruit() { FruitName = "Grape" });"\uf044"
        //fruits.Add(new Fruit() { FruitName = "Mango" });

        fruits.Add(new Fruit() { FruitName = "Apple", FruitDescription = "Description 1", ImageSource = "logo.png" });
        fruits.Add(new Fruit() { FruitName = "Orange", FruitDescription = "Description 2", ImageSource = "logo.png" });
        fruits.Add(new Fruit() { FruitName = "Banana", FruitDescription = "Description 3", ImageSource = "logo.png" });
        fruits.Add(new Fruit() { FruitName = "Grape", FruitDescription = "Description 4", ImageSource = "logo.png" });
        fruits.Add(new Fruit() { FruitName = "Mango", FruitDescription = "Description 5", ImageSource = "logo.png" });
        FruitListView.ItemsSource = fruits;
    }

    private async void EditButton_Clicked(object sender, EventArgs e)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        ImageButton button = (ImageButton)sender;
        if (button.BindingContext is Fruit fruitToShow)
        {
            SelectedFruit = fruitToShow;
            string message = $"Hello, you selected {fruitToShow.FruitName}!";
            await Toast.Make(message, ToastDuration.Long, 16)
                       .Show(cancellationTokenSource.Token);

           await Navigation.PushAsync(new EditKundali());

        }
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        if (button.BindingContext is Fruit fruitToDelete)
        {
            bool result = await DisplayAlert("Alert", "Are you sure you want to delete?", "OK", "Cancel");

            if (result)
            {
                fruits.Remove(fruitToDelete);
            }
        }



    }



    private async void FruitListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string? previous = (e.PreviousSelection.FirstOrDefault() as Fruit)?.FruitName;
        string? current = (e.CurrentSelection.FirstOrDefault() as Fruit)?.FruitName;

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        ImageButton button = (ImageButton)sender;


        if (button.BindingContext is Fruit fruitToshow)
        {

            await Toast.Make($" Hello {fruitToshow}" + previous + current,
            ToastDuration.Long,
                      16)
                .Show(cancellationTokenSource.Token);
        }

    }


    private async void Grid_Tapped(object sender, EventArgs e)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        ImageButton button = (ImageButton)sender;
        if (button.BindingContext is Fruit fruitToShow)
        {
            string message = $"Hello, you selected {fruitToShow.FruitName}!";
            await Toast.Make(message, ToastDuration.Long, 16)
                       .Show(cancellationTokenSource.Token);
        }
    }

    private void YourMethod()
    {
        // Your logic when the grid is single-clicked
    }

    private void DeleteButton_Clicked(object sender, TappedEventArgs e)
    {

    }

    //private async void CheckButton_Clicked(object sender, TappedEventArgs e)
    //{
    //    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    //    ImageButton button = (ImageButton)sender;
    //    if (button.BindingContext is Fruit fruitToShow)
    //    {
    //        string message = $"Hello, you selected {fruitToShow.FruitName}!";
    //        await Toast.Make(message, ToastDuration.Long, 16)
    //                   .Show(cancellationTokenSource.Token);
    //    }
    //}

    private async void CheckButton_Clicked(object sender, EventArgs e)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        ImageButton button = (ImageButton)sender;
        if (button.BindingContext is Fruit fruitToShow)
        {
            string message = $"Hello, you selected {fruitToShow.FruitName}!";
            await Toast.Make(message, ToastDuration.Long, 16)
                       .Show(cancellationTokenSource.Token);
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        if (((Grid)sender).BindingContext is Fruit fruitToShow)
        {
            SelectedFruit = fruitToShow;
            // Your logic using the Fruit item (fruitToShow)
            string message = $"Hello, you selected {fruitToShow.FruitName}!";
            Toast.Make(message, ToastDuration.Long, 16).Show(cancellationTokenSource.Token);
            Navigation.PushAsync(new Kundali());
        }
    }
}