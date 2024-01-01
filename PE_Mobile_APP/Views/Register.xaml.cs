
using PE_Mobile_APP.Model;
using System.Text;

namespace PE_Mobile_APP.Views;

public partial class Register : ContentPage
{
	public RegisterModel Model { get; set; }
	public Register()
	{
		InitializeComponent();
	    Model = new RegisterModel();
        BindingContext = Model;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

        try
        {

            HttpClient client = new HttpClient();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            //Bron https://www.youtube.com/watch?v=kvNhLKuAySA&ab_channel=AbhayPrince
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