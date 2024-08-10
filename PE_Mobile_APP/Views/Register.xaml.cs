
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

            //Converteert de gegevens in het object Model naar een JSON-string
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            //Stuurt de RegisterModel naar de sql database
            HttpResponseMessage response = await client.PostAsync("http://10.0.2.2:5084/api/Register/RegisterUser", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Registration successful!", "OK");
                
            }
            else
            {
                await DisplayAlert("Error", "Registration failed.", "OK");
                
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
        }



    }
}