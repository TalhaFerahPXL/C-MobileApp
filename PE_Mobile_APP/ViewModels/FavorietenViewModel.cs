using PE_Mobile_APP.Model;
using PE_Mobile_APP.Services;
using PE_Mobile_APP.Services.Interface;
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

        //singleton desing https://www.tutorialsteacher.com/csharp/singleton
        private static FavorietenViewModel _instance;
        public static FavorietenViewModel Instance => _instance ??= new FavorietenViewModel(new FavorietenRepository(new HttpClient())); 


        private IFavorietenRepository _repository;
        public ObservableCollection<Car> FavorieteAutoLijst { get; }

       
        private FavorietenViewModel(IFavorietenRepository repository)
        {
            _repository = repository;
            FavorieteAutoLijst = new ObservableCollection<Car>();
            LoadFavorieten();
        }

        private async void LoadFavorieten()
        {
            int userId = Convert.ToInt32(Preferences.Get("UserId", "defaultUserId"));
            try
            {
                var cars = await _repository.GetFavoriteCarsAsync(userId);
                FavorieteAutoLijst.Clear();
                foreach (var car in cars)
                {
                    FavorieteAutoLijst.Add(car);
                }
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                FavorieteAutoLijst.Clear();
            }
        }


        public async Task VoegFavorietToe(Car auto)
        {
            if (!FavorieteAutoLijst.Any(x => x.AutoId == auto.AutoId))
            {
                int userId = Convert.ToInt32(Preferences.Get("UserId", "defaultUserId"));
                if (await _repository.AddFavoriteCarAsync(userId, auto))
                {
                    FavorieteAutoLijst.Add(auto);
                }
            }
        }

        public async Task VerwijderFavoriet(Car auto)
        {
            int userId = Convert.ToInt32(Preferences.Get("UserId", "defaultUserId"));
            if (await _repository.RemoveFavoriteCarAsync(userId, auto.AutoId))
            {
                FavorieteAutoLijst.Remove(auto);
            }
        }
    }

}
