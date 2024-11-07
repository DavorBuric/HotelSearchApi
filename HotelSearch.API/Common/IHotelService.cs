using HotelSearch.API.Models;

namespace HotelSearch.API.Common
{
    public interface IHotelService
    {
        Task<HotelModel> GetHotelByIdAsync(int id);
        Task<List<HotelModel>> GetAllHotelsAsync();
        Task<HotelModel> CreateHotelAsync(HotelModel hotel);
        Task<HotelModel> UpdateHotelAsync(HotelModel hotel);
        Task<bool> DeleteHotelAsync(int id);
        Task<IEnumerable<HotelSearchModel>> SearchHotelsAsync(LocationModel location);
    }
}
