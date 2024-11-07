namespace HotelSearch.API.Models
{
    public class HotelSearchModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Distance { get; set; }
        public double? Score { get; set; }

    }
}
