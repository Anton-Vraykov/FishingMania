
using FishingMania.Data.Models;
using FishingMania.Services.Data.Models.EventModels;


namespace FishingMania.Services.Data.Interface_and_services.Events
{
    public interface IEvent
    {
        Task<List<Event>> ShowAllPlaceAsync(int skip, int take);
        public int GetEventCountAsync();
        List<EventViewModel> GetEventsViewModel(List<Event> source);
        EventViewModel GetEventViewModel(Event h);
        Task AddEventAsync(AddEventViewModel place, string userId, Guid Id);
        Task<EventDetailViewModel> GetEditEventModelAsync(Guid id);
        Task<Event> GetByIdAsync(Guid id);
        Task EditEventAsync(EventDetailViewModel model, Event even);
        Task DeleteEventAsync(Event hotel);

    }
}
