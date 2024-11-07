namespace HotelSearch.API.Models
{
    public class HotelModel
    {
        //parameters which will come from the database
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
