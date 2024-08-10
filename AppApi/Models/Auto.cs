namespace AppApi.Models
{
    public class Auto
    {
        public int AutoId { get; set; }
        public string Make { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
        public string Kilometers { get; set; }
        public string Description { get; set; }
    }
}
