using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PE_Mobile_APP.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;





       
        [RelayCommand]
        public async Task Register()
        {
            try
            {
               
                var registrationData = new
                {
                    naam = this.Name,
                    email = this.Email,
                    wachtwoord = this.Password
                };

                var json = JsonConvert.SerializeObject(registrationData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync("http://10.0.2.2:5084/api/Register/RegisterUser", content);

                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Registratie succesvol!", "OK");
                    await Application.Current.MainPage.Navigation.PushAsync(new Login(registrationData.email));

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Registration mislukt.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
            }
        }



       
    }
}
