using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PE_Mobile_APP.Model;
using System.Reflection;

namespace PE_Mobile_APP.Views;

public partial class Home : ContentPage
{
    private const string ApiBaseUrl = "http://10.0.2.2:5084/Home/GetAutos"; 

    public Home()
	{
		InitializeComponent();
        LoadCarsAsync();

        //Haalt gebruikersnaam
        string naam = Preferences.Get("GebruikersNaam", "User");

        //wordt gezocht naar het eerste kind dat een en als gevonden wordt de label.text aangepast
        AppShell shell = (AppShell)Application.Current.MainPage;
        var flyoutHeader = (StackLayout)shell.FlyoutHeader;
        var label = flyoutHeader.Children.FirstOrDefault(c => c is Label) as Label;

        if (label != null)
        {
            label.Text = $"Hallo {naam}!";
        }

    }

    //Geeft de toegevoede autos weer wanneer je terug naar home pagina kom
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadCarsAsync(); 
    }


    //Haalt de auto's objecten van de database via GetAsync en geeft ze weer in een list 
    private async Task<List<Car>> GetCarsAsync()
    {
        List<Car> cars = new List<Car>();

        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{ApiBaseUrl}"); 

                if (response.IsSuccessStatusCode)
                {
                    string carsJson = await response.Content.ReadAsStringAsync();
                    cars = JsonConvert.DeserializeObject<List<Car>>(carsJson);
                }
                else
                {
                    
                    Console.WriteLine("Fout bij het ophalen van auto's. Statuscode: " + response.StatusCode);
                }
            }
        }
        catch (Exception ex)
        {
            
            Console.WriteLine("Er is een fout opgetreden: " + ex.Message);
        }

        return cars;
    }

    private async void LoadCarsAsync()
    {
        List<Car> cars = await GetCarsAsync(); 

        carListView.ItemsSource = cars; 
    }

    private async void OnDetailsClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Car selectedCar)
        {
            await Navigation.PushAsync(new CarDetails(selectedCar));
        }
    }



    //De methode sorteert de auto's op basis van de geselecteerde filteroptie en vernieuwt de weergave 
    private void Filter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carListView.ItemsSource != null && carListView.ItemsSource is List<Car> cars)
        {
            var selectedFilter = Filter.SelectedItem as string;

            
            switch (selectedFilter)
            {
                case "Prijs oplopend":
                    cars = cars.OrderBy(c => Convert.ToDouble(c.Price)).ToList();
                    break;
                case "Prijs aflopend":
                    cars = cars.OrderByDescending(c => Convert.ToDouble(c.Price)).ToList();
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







