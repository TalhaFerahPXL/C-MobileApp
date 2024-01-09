using PE_Mobile_APP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Mobile_APP.ViewModels
{
    public class FavorietenViewModel : BindableObject
    {
        private static FavorietenViewModel _instance;

        public static FavorietenViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FavorietenViewModel();

                return _instance;
            }
        }

        private ObservableCollection<Car> _favorieteAutoLijst;

        public ObservableCollection<Car> FavorieteAutoLijst
        {
            get => _favorieteAutoLijst;
            set
            {
                _favorieteAutoLijst = value;
                OnPropertyChanged();
            }
        }

        private FavorietenViewModel()
        {
            FavorieteAutoLijst = new ObservableCollection<Car>();
        }

        public void VoegFavorietToe(Car auto)
        {
            if (!FavorieteAutoLijst.Any(x => x.AutoId == auto.AutoId))
            {
                FavorieteAutoLijst.Add(auto);
            }
        }

        public void VerwijderFavoriet(Car auto)
        {
            var gevondenAuto = FavorieteAutoLijst.FirstOrDefault(x => x.AutoId == auto.AutoId);
            if (gevondenAuto != null)
            {
                FavorieteAutoLijst.Remove(gevondenAuto);
            }
        }


    }
}
