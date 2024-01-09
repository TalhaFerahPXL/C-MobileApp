using PE_Mobile_APP.Model;
using System.Net;

namespace PE_Mobile_APP.Views;

public partial class CarDetails : ContentPage
{
	public CarDetails(Car car)
	{
		InitializeComponent();
        BindingContext = car;
    }

    private async void OnBuyClicked(object sender, EventArgs e)
    {
        if (BindingContext is Car car)
        {
            int autoId = car.AutoId;


            HttpClient client = new HttpClient();




            string apiUrl = $"http://10.0.2.2:5084/Home/?id={autoId}";

            HttpResponseMessage response = await client.DeleteAsync(apiUrl);


            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Aankoop voltooid", "Je hebt de auto succesvol gekocht", "OK");

            }


        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Car selectedCar)
        {
            FavorietenViewModel.Instance.VoegFavorietToe(selectedCar);
            await DisplayAlert("Toegevoegd aan favorieten", $"{selectedCar.Make} is toegevoegd aan jouw favorieten", "OK");
        }
    }
}