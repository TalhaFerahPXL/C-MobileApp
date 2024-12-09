using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;

namespace PE_Mobile_APP.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private bool isErrorVisible;

        public LoginViewModel()
        {
            IsErrorVisible = false;
        }

        [RelayCommand]
        public async Task LoginAsync()
        {
            var loginData = new
            {
              
                email = this.Email,
                wachtwoord = this.Password
            };


            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage loginResponse = await client.PostAsync("http://10.0.2.2:5084/api/Login/LoginUser", content);

            if (loginResponse.IsSuccessStatusCode)
            {
                HttpResponseMessage response = await client.GetAsync($"http://10.0.2.2:5084/api/Login/GetUserNameByEmail?email={Email}");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var userDetails = JsonConvert.DeserializeObject<dynamic>(responseContent);

                    Preferences.Set("GebruikersNaam", (string)userDetails.userName);
                    Preferences.Set("UserId", (string)userDetails.userId);

                    await Shell.Current.GoToAsync("//Home");
                }
                else
                {
                    IsErrorVisible = true;
                }
            }
            else
            {
                IsErrorVisible = true;
            }
        }
    }
}
