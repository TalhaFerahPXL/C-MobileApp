using PE_Mobile_APP.Model;
using PE_Mobile_APP.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PE_Mobile_APP.Services
{
    public class FavorietenRepository : IFavorietenRepository
    {
        private HttpClient _httpClient;
        private string _baseUrl = "http://10.0.2.2:5084/Favoriet";

        public FavorietenRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        

        public async Task<List<Car>> GetFavoriteCarsAsync(int userId)
        {
            var url = $"{_baseUrl}/GetFavoriteCars?userId={userId}";
            return await _httpClient.GetFromJsonAsync<List<Car>>(url);
        }

        public async Task<bool> AddFavoriteCarAsync(int userId, Car car)
        {
            var requestBody = new { userId = userId, autoId = car.AutoId };
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/AddCarToFavorite", requestBody);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveFavoriteCarAsync(int userId, int carId)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/RemoveCarFromFavorite?userId={userId}&autoId={carId}");
            return response.IsSuccessStatusCode;
        }
    }
}
