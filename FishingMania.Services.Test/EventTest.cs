
using FishingMania.Data.Models;
using FishingMania.Data;
using Microsoft.EntityFrameworkCore;
using FishingMania.Services.Data.Interface_and_services.Events;

namespace FishingMania.Services.Test
{
    public class EventTest
    {
        private IEvent eventService;
        private List<Event> events;


        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("FishingManiaTestDb")
                .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);


            events = new List<Event>
            {
                new Event
                {
                  Id = Guid.NewGuid(),
                  Name = "Drinking cups of wine",
                  ImageURL = "https://www.eatingwell.com/thmb/hmkghQ7jiNId8-LYlrpZBy1-MUM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/wine-gettyimages-160836693_1_0-f2322da3687d4dafbcbdd7d52cf86064.jpg",
                  Location = ".",
                  Description = "The Wine Festival is an event where wine, culture and cuisine merge into one, creating a space for those who love life in all its flavors, colors and shades. The city wine festival is dedicated to the diversity of local wine grape varieties, with which Bulgarian winemakers give the authentic appearance of Bulgarian wine.The rezervation for this event is for last day ot the fishingdays.GSM FOR RESERVATION 088*********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  FreePlace = 50,
                  Price = 50,
                  FishingPlaceId = Guid.NewGuid()
                },
                new Event
                {
                  Id = Guid.NewGuid(),
                  Name = "Drinking cups of rakia",
                  ImageURL = "https://www.eatingwell.com/thmb/hmkghQ7jiNId8-LYlrpZBy1-MUM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/wine-gettyimages-160836693_1_0-f2322da3687d4dafbcbdd7d52cf86064.jpg",
                  Location = ".",
                  Description = "The Wine Festival is an event where rakia, culture and cuisine merge into one, creating a space for those who love life in all its flavors, colors and shades. The city rakia festival is dedicated to the diversity of local rakia grape varieties, with which Bulgarian rakiamakers give the authentic appearance of Bulgarian rakia.The rezervation for this event is for last day ot the fishingdays.GSM FOR RESERVATION 088*********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  FreePlace = 50,
                  Price = 50,
                  FishingPlaceId = Guid.NewGuid()
                }
            };

            context.Events.AddRange(events);
            context.SaveChanges();

            eventService = new EventServices(context);
        }

        [Test]
        public async Task GetByIdAsync()
        {

            var eventId = events[0].Id;


            var result = await eventService.GetByIdAsync(eventId);


            Assert.AreEqual(eventId, result.Id);
            Assert.AreEqual("Drinking cups of wine", result.Name);
        }
        [Test]
        public async Task GetByIdAsync1()
        {

            var Id = Guid.NewGuid();


            var ex = Assert.ThrowsAsync<Exception>(() => eventService.GetByIdAsync(Id));
            Assert.AreEqual("There is no events", ex.Message);

        }
        [Test]
        public async Task ShowAllPlaceAsync()
        {

            var result = await eventService.ShowAllPlaceAsync(0, 10);


            Assert.AreEqual(2, result.Count / 3);
        }
        [Test]
        public async Task DeleteEventAsync()
        {

            var events = this.events[0];


            await eventService.DeleteEventAsync(events);


            Assert.IsTrue(events.IsDeleted);

        }
    }
}
