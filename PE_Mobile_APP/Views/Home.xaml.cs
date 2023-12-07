using PE_Mobile_APP.Model;

namespace PE_Mobile_APP.Views;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();


        List<Car> cars = new List<Car>
        {
            new Car { Make = "Mercedes-Benz", Kilometers = "2000", Year = 2022, ImageUrl = "m5csbanner.jpg", Price = "1000", Description = "M5cs .. M5cs .. M5cs ..M5cs ..M5cs ..M5cs .." },
                     new Car { Make = "Mercedes-Benz", Kilometers = "2000", Year = 2022, ImageUrl = "m5csbanner.jpg", Price = "1000", Description = "M5cs .. M5cs .. M5cs ..M5cs ..M5cs ..M5cs .." },

            //new Car { Make = "BMW", Model = "3 Series", Year = 2021, ImageUrl = "car2.jpg" },
            
        };

        carListView.ItemsSource = cars;


       

    }


    private async void OnDetailsClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Car selectedCar)
        {
            await Navigation.PushAsync(new CarDetails(selectedCar));
        }
    }


}