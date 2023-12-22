using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PE_Mobile_APP.Model;
using System.Reflection;

namespace PE_Mobile_APP.Views;

public partial class Home : ContentPage
{
    private const string ApiBaseUrl = "http://10.0.2.2:5084/Home/GetAutos"; // Vervang dit met de juiste URL van jouw API

    public Home()
	{
		InitializeComponent();
        LoadCarsAsync();

        string naam = Preferences.Get("GebruikersNaam", "User");

        AppShell shell = (AppShell)Application.Current.MainPage;
        var flyoutHeader = (StackLayout)shell.FlyoutHeader;
        var label = flyoutHeader.Children.FirstOrDefault(c => c is Label) as Label;

        if (label != null)
        {
            label.Text = $"Hallo {naam}!";
        }

    }


    private async Task<List<Car>> GetCarsAsync()
    {
        List<Car> cars = new List<Car>();

        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{ApiBaseUrl}"); // Vervang "/cars" met het juiste eindpunt van jouw API

                if (response.IsSuccessStatusCode)
                {
                    string carsJson = await response.Content.ReadAsStringAsync();
                    cars = JsonConvert.DeserializeObject<List<Car>>(carsJson);
                }
                else
                {
                    // Behandel eventuele fouten bij het ophalen van gegevens
                    Console.WriteLine("Fout bij het ophalen van auto's. Statuscode: " + response.StatusCode);
                }
            }
        }
        catch (Exception ex)
        {
            // Behandel eventuele uitzonderingen
            Console.WriteLine("Er is een fout opgetreden: " + ex.Message);
        }

        return cars;
    }

    private async void LoadCarsAsync()
    {
        List<Car> cars = await GetCarsAsync(); // Roep de GetCarsAsync-methode aan om de auto-objecten op te halen

        carListView.ItemsSource = cars; // Wijs de lijst met auto-objecten toe aan de ItemsSource van carListView
    }

    private async void OnDetailsClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Car selectedCar)
        {
            await Navigation.PushAsync(new CarDetails(selectedCar));
        }
    }



    private void Filter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carListView.ItemsSource != null && carListView.ItemsSource is List<Car> cars)
        {
            var selectedFilter = Filter.SelectedItem as string;

            switch (selectedFilter)
            {
                case "Prijs oplopend":
                    cars = cars.OrderByDescending(c => c.Price).ToList();
                    break;
                case "Prijs aflopend":
                    
                    cars = cars.OrderBy(c => c.Price).ToList();
                    break;
                case "Bouwjaar oplopend":
                    cars = cars.OrderBy(c => c.Year).ToList();
                    break;
                case "Bouwjaar aflopend":
                    cars = cars.OrderByDescending(c => c.Year).ToList();
                    break;
                default:
                    break;
            }

            carListView.ItemsSource = cars; 
        }
    }
}







