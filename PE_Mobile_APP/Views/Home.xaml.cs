using PE_Mobile_APP.Model;

namespace PE_Mobile_APP.Views;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();


        List<Car> cars = new List<Car>
        {
            new Car { Make = "Mercedes-Benz", Kilometers = "2000km", Year = 2022, ImageUrl = "m5csbanner.jpg", Price = "1000" },
            //new Car { Make = "BMW", Model = "3 Series", Year = 2021, ImageUrl = "car2.jpg" },
            // Voeg meer auto's toe zoals nodig
        };

        carListView.ItemsSource = cars;
    }


}