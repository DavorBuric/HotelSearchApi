using HotelSearch.API.Common;
using HotelSearch.API.DAL;
using HotelSearch.API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotelSearch.API.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DataLayer _dataLayer;

        public HotelRepository(DataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public async Task<HotelModel> GetHotelByIdAsync(int id)
        {
            var hotel = new HotelModel
            {
                Id = id,
                Name = "Mock Hotel " + id,
                Price = 100.00 + id,
                Latitude = 40.0 + id,
                Longitude = -75.0 - id
            };
            return await Task.FromResult(hotel);
        }

        public async Task<List<HotelModel>> GetAllHotelsAsync()
        {
            var hotels = new List<HotelModel>
            {
                new HotelModel
                {
                    Id = 1,
                    Name = "Grand Plaza Hotel",
                    Price = 99.99,
                    Latitude = 40.7128,
                    Longitude = -74.0060
                },
                new HotelModel
                {
                    Id = 2,
                    Name = "Sunset Resort",
                    Price = 129.99,
                    Latitude = 34.0522,
                    Longitude = -118.2437
                },
                new HotelModel
                {
                    Id = 3,
                    Name = "Mountain View Lodge",
                    Price = 79.99,
                    Latitude = 39.7392,
                    Longitude = -104.9903
                },
                new HotelModel
                {
                    Id = 4,
                    Name = "Lakeside Inn",
                    Price = 89.99,
                    Latitude = 45.4215,
                    Longitude = -75.6972
                },
                new HotelModel
                {
                    Id = 5,
                    Name = "Ocean Breeze Hotel",
                    Price = 199.99,
                    Latitude = 25.7617,
                    Longitude = -80.1918
                },
                new HotelModel
                {
                    Id = 6,
                    Name = "Golden Sands Resort",
                    Price = 159.99,
                    Latitude = 26.1223,
                    Longitude = -80.1430
                },
                new HotelModel
                {
                    Id = 7,
                    Name = "City Lights Hotel",
                    Price = 129.00,
                    Latitude = 51.5074,
                    Longitude = -0.1278
                },
                new HotelModel
                {
                    Id = 8,
                    Name = "Skyline Inn",
                    Price = 149.99,
                    Latitude = 48.8566,
                    Longitude = 2.3522
                },
                new HotelModel
                {
                    Id = 9,
                    Name = "Historic Downtown Hotel",
                    Price = 169.99,
                    Latitude = 40.748817,
                    Longitude = -73.985428
                },
                new HotelModel
                {
                    Id = 10,
                    Name = "Desert Oasis Resort",
                    Price = 239.99,
                    Latitude = 36.1699,
                    Longitude = -115.1398
                }
            };

            return await Task.FromResult(hotels);
        }

        public async Task<HotelModel> CreateHotelAsync(HotelModel hotel)
        {
            //SQL stored procedure call example
            //var parameters = new List<SqlParameter>
            //{
            //    new SqlParameter("@Name", SqlDbType.NVarChar) { Value = hotel.Name },
            //    new SqlParameter("@Price", SqlDbType.Float) { Value = hotel.Price },
            //    new SqlParameter("@Latitude", SqlDbType.Float) { Value = hotel.Latitude },
            //    new SqlParameter("@Longitude", SqlDbType.Float) { Value = hotel.Longitude }
            //};

            //var result = await _dataLayer.GetData<HotelModel>("AddHotel", parameters);
            return await Task.FromResult(hotel);
        }

        public async Task<HotelModel> UpdateHotelAsync(HotelModel hotel)
        {
            return await Task.FromResult(hotel);
        }

        public async Task<bool> DeleteHotelAsync(int id)
        {
            return await Task.FromResult(true);
        }
    }
}
