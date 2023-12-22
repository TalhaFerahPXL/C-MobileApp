using Microsoft.Maui.ApplicationModel.Communication;
using System.Text;

namespace PE_Mobile_APP.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {

        string Email = email.Text;
        string Wachtwoord = wachtwoord.Text;

        var loginData = new
        {
            Email = Email,
            Wachtwoord = Wachtwoord
        };

        HttpClient client = new HttpClient();
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(loginData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("http://10.0.2.2:5084/api/Login/LoginUser", content);


        //HttpResponseMessage responseMessage = await client.GetAsync("http://10.0.2.2:5084/api/Login/GetUserNameByEmail");
        HttpResponseMessage responseMessage = await client.GetAsync($"http://10.0.2.2:5084/api/Login/GetUserNameByEmail?email={Email}");


        //als response == 200 => succes
        if (response.IsSuccessStatusCode)
        {
            
            string naam = await responseMessage.Content.ReadAsStringAsync();

            Preferences.Set("GebruikersNaam", naam);
            
            




            await Shell.Current.GoToAsync("//Home");
        }
        else
        {
            // Onjuiste inloggegevens
            foutTxt.IsVisible = true;

        }
        


        
    }
}