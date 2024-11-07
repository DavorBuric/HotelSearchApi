using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSearch.Service
{
    public class HotelService
    {
        private readonly List<HotelModel> _hotels; // In-memory list for simulating a database

        public HotelService()
        {
            // Initialize with some dummy data (can be replaced with actual database logic)
            _hotels = new List<HotelModel>
            {
                new HotelModel(1, "Hotel A", 100, 40.7128, -74.0060),
                new HotelModel(2, "Hotel B", 150, 34.0522, -118.2437),
                new HotelModel(3, "Hotel C", 200, 51.5074, -0.1278)
            };
        }

        // Get a hotel by ID
        public async Task<HotelModel> GetHotelByIdAsync(int id)
        {
            var hotel = _hotels.FirstOrDefault(h => h.Id == id);
            return await Task.FromResult(hotel);
        }

        // Get all hotels
        public async Task<List<HotelModel>> GetAllHotelsAsync()
        {
            return await Task.FromResult(_hotels);
        }

        // Create a new hotel
        public async Task<HotelModel> CreateHotelAsync(HotelModel hotel)
        {
            hotel.Id = _hotels.Count + 1;  // Simple ID generation logic (incremental)
            _hotels.Add(hotel);
            return await Task.FromResult(hotel);
        }

        // Update an existing hotel
        public async Task<HotelModel> UpdateHotelAsync(HotelModel hotel)
        {
            var existingHotel = _hotels.FirstOrDefault(h => h.Id == hotel.Id);
            if (existingHotel == null) return null;

            // Update the hotel properties
            existingHotel.Name = hotel.Name;
            existingHotel.Price = hotel.Price;
            existingHotel.Latitude = hotel.Latitude;
            existingHotel.Longitude = hotel.Longitude;

            return await Task.FromResult(existingHotel);
        }

        // Delete a hotel by ID
        public async Task<bool> DeleteHotelAsync(int id)
        {
            var hotel = _hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null) return await Task.FromResult(false);

            _hotels.Remove(hotel);
            return await Task.FromResult(true);
        }
    }
}
