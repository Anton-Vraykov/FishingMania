
using FishingMania.Data.Models;
using FishingMania.Models.HotelModels;
using FishingMania.Services.Data.Models.EventModels;
using FishingMania.Services.Data.Models.HotelModels;

namespace FishingMania.Services.Data.Interface_and_services.Events
{
    public interface IEvent
    {
        Task<List<Event>> ShowAllPlaceAsync(int skip, int take);
        public int GetEventCountAsync();
        List<EventViewModel> GetEventsViewModel(List<Event> source);
        EventViewModel GetEventViewModel(Event h);
        Task AddEventAsync(AddEventViewModel place, string userId, Guid Id);
        //Task<HotelDetailViewModel> GetEditHotelModelAsync(Guid id);
        //Task<Hotel> GetByIdAsync(Guid id);
        //Task EditHotelAsync(HotelDetailViewModel model, Hotel hotel);
        //Task DeleteHotelAsync(Hotel hotel);

    }
}
