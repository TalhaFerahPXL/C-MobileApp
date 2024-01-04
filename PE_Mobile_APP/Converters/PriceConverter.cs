using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Mobile_APP.Converters
{
    public class PriceConverter : IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && decimal.TryParse(value.ToString(), out decimal price))
            {
                return $"Prijs: €{price:F2}";
            }

            return "Prijs: € 0.00";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
