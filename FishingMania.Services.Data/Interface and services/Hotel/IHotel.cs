using FishingMania.Data.Models;
using FishingMania.Models;
using FishingMania.Models.HotelModels;

namespace FishingMania.Data.Interface
{
    public interface IHotel
    {
        Task<List<Hotel>> ShowAllPlaceAsync(int skip, int take);
        Task<int> GetHotelCountAsync();
        List<HotelViewModel> GetHotelsViewModel(List<Hotel> source);
        HotelViewModel GetHotelViewModel(Hotel h);
    }
}
