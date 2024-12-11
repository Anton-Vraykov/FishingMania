using FishingMania.Data.Models;
using FishingMania.Models;
using FishingMania.Models.HotelModels;
using FishingMania.Services.Data.Models.HotelModels;

namespace FishingMania.Data.Interface
{
    public interface IHotel
    {
        Task<List<Hotel>> ShowAllPlaceAsync(int skip, int take,Guid Id);
        public int GetHotelCountAsync();
        List<HotelViewModel> GetHotelsViewModel(List<Hotel> source);
        HotelViewModel GetHotelViewModel(Hotel h);
        Task AddHotelAsync(AddHotelViewModel place, string userId, Guid Id);
        Task<HotelDetailViewModel> GetEditHotelModelAsync(Guid id);
        Task<Hotel> GetByIdAsync(Guid id);
        Task EditHotelAsync(HotelDetailViewModel model, Hotel hotel);
        Task DeleteHotelAsync(Hotel hotel);

    }
}
