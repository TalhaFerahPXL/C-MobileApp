using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace PE_Mobile_APP.Views
{
    public partial class Settings : ContentPage
    {
        string huidigeNaam;
        public int UserId = int.Parse(Preferences.Get("UserId", "0")); 
        private HttpClient _httpClient = new HttpClient();

        public Settings()
        {
            InitializeComponent();
            huidigeNaam = Preferences.Get("GebruikersNaam", "User");
            nameEntry.Text = huidigeNaam;
            
        }

        private async void OnUpdateClicked(object sender, EventArgs e)
        {
            var settings = new
            {
                UserId = this.UserId,
                Naam = nameEntry.Text
            };

            var content = new StringContent(JsonSerializer.Serialize(settings), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://10.0.2.2:5084/Settings/ChangeName", content);
            if (response.IsSuccessStatusCode)
            {
                Preferences.Set("GebruikersNaam", settings.Naam);
                AppShell shell = (AppShell)Application.Current.MainPage;
                var flyoutHeader = (StackLayout)shell.FlyoutHeader;
                var label = flyoutHeader.Children.FirstOrDefault(c => c is Label) as Label;
                nameEntry.IsEnabled = false;
                label.Text = $"Hallo {settings.Naam}!";
                
                await DisplayAlert("Success", "Uw naam is bijgewerkt.", "OK");
                
            }
            else
            {
                await DisplayAlert("Error", "Naam bijwerken is mislukt.", "OK");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            nameEntry.IsEnabled = true;
        }
    }
}
