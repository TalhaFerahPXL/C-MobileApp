using PE_Mobile_APP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PE_Mobile_APP.ViewModels
{
    public class FavorietenViewModel : BindableObject
    {
        private static FavorietenViewModel _instance;
        private HttpClient _httpClient;
        private string _baseUrl = "http://10.0.2.2:5084/Favoriet";

        public static FavorietenViewModel Instance => _instance ??= new FavorietenViewModel();

        public ObservableCollection<Car> FavorieteAutoLijst { get; private set; }

        private FavorietenViewModel()
        {

            _httpClient = new HttpClient();
            FavorieteAutoLijst = new ObservableCollection<Car>();
            HaalFavorietenOp();
        }


        public async void HaalFavorietenOp()
        {
            int userId = Convert.ToInt32(Preferences.Get("UserId", "defaultUserId"));
            try
            {
                var cars = await _httpClient.GetFromJsonAsync<List<Car>>($"http://10.0.2.2:5084/Favoriet/GetFavoriteCars?userId={userId}");
                if (cars != null)
                {
                    FavorieteAutoLijst.Clear();
                    foreach (var car in cars)
                    {
                        FavorieteAutoLijst.Add(car);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching favorite cars: " + ex.Message);

            }
        }

        

        public async Task VoegFavorietToe(Car auto)
        {
            if (!FavorieteAutoLijst.Any(x => x.AutoId == auto.AutoId))
            {
                int userId = Convert.ToInt32(Preferences.Get("UserId", "defaultUserId"));
                int autoId = auto.AutoId;

                var requestBody = new { userId = userId, autoId = autoId };
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("http://10.0.2.2:5084/Favoriet/AddCarToFavorite", requestBody);

                if (response.IsSuccessStatusCode)
                {
                    FavorieteAutoLijst.Add(auto);
                }
                else
                {
                    Console.WriteLine("Failed to add car to favorites: " + response.StatusCode);
                }
            }
        }


        public async Task VerwijderFavoriet(Car auto)
        {
            int userId = Convert.ToInt32(Preferences.Get("UserId", "defaultUserId"));
            int autoId = auto.AutoId;


            var response = await _httpClient.DeleteAsync($"http://10.0.2.2:5084/Favoriet/RemoveCarFromFavorite?userId={userId}&autoId={autoId}");
            if (response.IsSuccessStatusCode)
            {
                var gevondenAuto = FavorieteAutoLijst.FirstOrDefault(x => x.AutoId == auto.AutoId);
                if (gevondenAuto != null)
                {
                    FavorieteAutoLijst.Remove(gevondenAuto);
                }
            }
            else
            {
                Console.WriteLine("Failed to remove car from favorites: " + response.StatusCode);
            }
        }



    }
}
