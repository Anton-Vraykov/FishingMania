
using FishingMania.Data;
using FishingMania.Data.Models;
using FishingMania.Services.Data.Interface_and_services.Events;
using FishingMania.Services.Data.Models.CarModels;
using FishingMania.Services.Data.Models.EventModels;
using Microsoft.EntityFrameworkCore;

namespace FishingMania.Services.Data.Interface_and_services.Events
{
    public class EventServices:IEvent
    {
        private readonly ApplicationDbContext db;
        public EventServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddEventAsync(AddEventViewModel place, string userId, Guid Id)
        {
            if (place.Price < 0)
            {
                return;
            }
            var placeData = new Event
            {

                Name = place.Name,
                Description = place.Description,
                ImageURL = place.ImageURL,
                Location = place.Location,
                UserId = userId,
                Price = place.Price,
                FreePlace = place.FreePlace,
                FishingPlaceId = Id

            };
            await db.Events.AddAsync(placeData);
            await db.SaveChangesAsync();
        } 
        public int GetEventCountAsync()=> this.db.Events.Where(e=>e.IsDeleted==false).Count();
        

        public List<EventViewModel> GetEventsViewModel(List<Event> source)
        {
            var evens = new List<EventViewModel>();


            foreach (var even in source)
            {
                evens.Add(GetEventViewModel(even));
            }

            return evens;
        }

        public EventViewModel GetEventViewModel(Event h)
        {
            return new EventViewModel
            {
                Id = h.Id,
                Name = h.Name,
                ImageURL = h.ImageURL,
                Location = h.Location,
                Description = h.Description,
                FreePlace = h.FreePlace,
                Price = h.Price

            };
        }

        public async Task<List<Event>> ShowAllPlaceAsync(int skip, int take)
        {
            return await this.db.Events.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }
    }
}
