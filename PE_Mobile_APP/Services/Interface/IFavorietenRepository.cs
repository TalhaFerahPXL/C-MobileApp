using PE_Mobile_APP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Mobile_APP.Services.Interface
{
    public interface IFavorietenRepository
    {
        Task<List<Car>> GetFavoriteCarsAsync(int userId);
        Task<bool> AddFavoriteCarAsync(int userId, Car car);
        Task<bool> RemoveFavoriteCarAsync(int userId, int carId);
    }
}
