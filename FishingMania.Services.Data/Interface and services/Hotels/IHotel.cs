using FishingMania.Data.Models;
using FishingMania.Models;
using FishingMania.Models.HotelModels;
using FishingMania.Services.Data.Models.HotelModels;

namespace FishingMania.Data.Interface
{
    public interface IHotel
    {
        Task<List<Hotel>> ShowAllPlaceAsync(int skip, int take);
        public int GetHotelCountAsync();
        List<HotelViewModel> GetHotelsViewModel(List<Hotel> source);
        HotelViewModel GetHotelViewModel(Hotel h);
        Task AddHotelAsync(AddHotelViewModel place, string userId, Guid Id);
        
    }
}
