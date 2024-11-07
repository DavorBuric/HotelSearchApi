using HotelSearch.API.Common;
using HotelSearch.API.Helpers;
using HotelSearch.API.Models;
using HotelSearch.API.Repositories;
using Microsoft.Extensions.Hosting;

namespace HotelSearch.API.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<HotelModel> GetHotelByIdAsync(int id)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(id);
            return hotel;
        }

        public async Task<List<HotelModel>> GetAllHotelsAsync()
        {
            var hotels = await _hotelRepository.GetAllHotelsAsync();
            return hotels;
        }

        public async Task<HotelModel> CreateHotelAsync(HotelModel hotel)
        {
            var createdHotel = await _hotelRepository.CreateHotelAsync(hotel);
            return createdHotel;
        }

        public async Task<HotelModel> UpdateHotelAsync(HotelModel hotel)
        {
            var updatedHotel = await _hotelRepository.UpdateHotelAsync(hotel);
            return updatedHotel;
        }

        public async Task<bool> DeleteHotelAsync(int id)
        {
            var result = await _hotelRepository.DeleteHotelAsync(id);
            return result;
        }

        public async Task<IEnumerable<HotelSearchModel>> SearchHotelsAsync(LocationModel location)
        {
            IEnumerable<HotelModel> hotels = await _hotelRepository.GetAllHotelsAsync();

            IEnumerable<HotelSearchModel> scoredHotels = ScoringHelper.CalculateScores(hotels, location);

            return scoredHotels;
        }
    }
}
