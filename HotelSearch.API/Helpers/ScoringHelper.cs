using HotelSearch.API.Models;
using System.Collections.Generic;

namespace HotelSearch.API.Helpers
{
    public static class ScoringHelper
    {
        private const double EarthRadiusKm = 6371;
        //alpha and beta are importance weights of price and distance respectfully, and they could be passed to the function in order to allow user to set importance
        private const double alpha = 0.5;
        private const double beta = 0.5;
        public static IEnumerable<HotelSearchModel> CalculateScores(IEnumerable<HotelModel> hotels, LocationModel location)
        {
            var maxDistance = hotels.Max(hotel => CalculateDistance(location.Latitude, location.Longitude, hotel.Latitude, hotel.Longitude));
            var maxPrice = hotels.Max(hotel => hotel.Price);
            var minPrice = hotels.Min(hotel => hotel.Price);

            List<HotelSearchModel> scoredHotels = new List<HotelSearchModel>();

            foreach (var hotel in hotels)
            {
                var distance = CalculateDistance(location.Latitude, location.Longitude, hotel.Latitude, hotel.Longitude);
                var normalizedPrice = (hotel.Price - minPrice) / (maxPrice - minPrice);
                var normalizedDistance = distance / maxDistance;

                scoredHotels.Add(new HotelSearchModel
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Price = hotel.Price,
                    Latitude = hotel.Latitude,
                    Longitude = hotel.Longitude,
                    Distance = Math.Round(distance, 2),
                    Score = alpha * normalizedPrice + beta * normalizedDistance
                });
            }

            return scoredHotels.OrderBy(h => h.Score).ToList();
        }

        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var dLat = DegreesToRadians(lat2 - lat1);
            var dLon = DegreesToRadians(lon2 - lon1);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EarthRadiusKm * c;
        }

        private static double DegreesToRadians(double degrees) => degrees * (Math.PI / 180);

    }
}
