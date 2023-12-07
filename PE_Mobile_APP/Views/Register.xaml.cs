using PE_Mobile_APP.Controllers;
using System.Text;

namespace PE_Mobile_APP.Views;

public partial class Register : ContentPage
{
	
	public Register()
	{
		InitializeComponent();
	
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {

        string Naam = naam.Text;
        string Email = email.Text;
        string Wachtwoord = password.Text;


        try
        {
            string naam = Naam;
            string email = Email;
            string wachtwoord = Wachtwoord;

            var userData = new
            {
                naam,
                email,
                wachtwoord
            };
            //ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;




            HttpClient client = new HttpClient();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(userData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;


            //HttpResponseMessage responses = await client.GetAsync("http://10.0.2.2:5084/WeatherForecast");



            //https://www.youtube.com/watch?v=kvNhLKuAySA&ab_channel=AbhayPrince
            HttpResponseMessage response = await client.PostAsync("http://10.0.2.2:5084/api/Register/RegisterUser", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Registration successful!", "OK");
                // Handle success scenario
            }
            else
            {
                await DisplayAlert("Error", "Registration failed.", "OK");
                // Handle error scenario
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
        }



    }
}