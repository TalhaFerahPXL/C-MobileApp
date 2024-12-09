using PE_Mobile_APP.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PE_Mobile_APP.Model
{
    [Table("Autos")]
    public class Car
    {
        public int AutoId { get; set; }

        

        public string Make { get; set; }

        [JsonConverter(typeof(FlexibleDoubleConverter))]

        public double Price { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
        public string Kilometers { get; set; }

        public string Description { get; set; }
    }
}
