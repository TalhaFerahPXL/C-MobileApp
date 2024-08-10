using Microsoft.Maui.ApplicationModel.Communication;
using PE_Mobile_APP.Model;
using System.Text;

namespace PE_Mobile_APP.Views;

public partial class Login : ContentPage
{
    public LoginViewModel ViewModel { get; set; }

    public Login()
    {
        InitializeComponent();
        ViewModel = new LoginViewModel();
        BindingContext = ViewModel;
    }

    //private async void Button_Clicked(object sender, EventArgs e)
    //{
    //    HttpClient client = new HttpClient();
    //    var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
    //    var content = new StringContent(json, Encoding.UTF8, "application/json");

    //    HttpResponseMessage loginResponse = await client.PostAsync("http://10.0.2.2:5084/api/Login/LoginUser", content);

    //    if (loginResponse.IsSuccessStatusCode)
    //    {
    //        // Haalt gebruikersnaam en UserId op via email
    //        HttpResponseMessage response = await client.GetAsync($"http://10.0.2.2:5084/api/Login/GetUserNameByEmail?email={Model.Email}");
    //        if (response.IsSuccessStatusCode)
    //        {
    //            var responseContent = await response.Content.ReadAsStringAsync();
    //            var userDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseContent);

    //            Preferences.Set("GebruikersNaam", (string)userDetails.userName);
    //            Preferences.Set("UserId", (string)userDetails.userId);

    //            await Shell.Current.GoToAsync("//Home");
    //        }
    //        else
    //        {
    //            foutTxt.IsVisible = true;  
    //        }
    //    }
    //    else
    //    {
    //        foutTxt.IsVisible = true;  
    //    }
    //}

}