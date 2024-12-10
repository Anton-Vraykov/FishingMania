
using FishingMania.Data.Models;
using FishingMania.Data;
using Microsoft.EntityFrameworkCore;
using FishingMania.Services.Data.Interface_and_services.Events;

namespace FishingMania.Services.Test
{
    public class EventTest
    {
        private IEvent _eventService;
        private List<Event> _event;


        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("FishingManiaTestDb")
                .Options;

            ApplicationDbContext _context = new ApplicationDbContext(options);


            _event = new List<Event>
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

            _context.Events.AddRange(_event);
            _context.SaveChanges();

            _eventService = new EventServices(_context);
        }

        [Test]
        public async Task GetByIdAsync()
        {

            var eventId = _event[0].Id;


            var result = await _eventService.GetByIdAsync(eventId);


            Assert.AreEqual(eventId, result.Id);
            Assert.AreEqual("Drinking cups of wine", result.Name);
        }
        [Test]
        public async Task GetByIdAsync1()
        {

            var Id = Guid.NewGuid();


            var ex = Assert.ThrowsAsync<Exception>(() => _eventService.GetByIdAsync(Id));
            Assert.AreEqual("There is no events", ex.Message);

        }
        [Test]
        public async Task ShowAllPlaceAsync()
        {

            var result = await _eventService.ShowAllPlaceAsync(0, 10);


            Assert.AreEqual(2, result.Count / 3);
        }
        [Test]
        public async Task DeleteEventAsync()
        {

            var events = _event[0];


            await _eventService.DeleteEventAsync(events);


            Assert.IsTrue(events.IsDeleted);

        }
    }
}
