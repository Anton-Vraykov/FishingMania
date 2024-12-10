

using FishingMania.Data.Interface;
using FishingMania.Data.Models;
using FishingMania.Data;
using Microsoft.EntityFrameworkCore;
using System;
using FishingMania.Services.Data.Interface_and_services.Hotels;

namespace FishingMania.Services.Test
{
    public class HotelTest
    {
       
        private IHotel _hotelService;
        private List<Hotel> _hotel;


        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("FishingManiaTestDb")
                .Options;

            ApplicationDbContext _context = new ApplicationDbContext(options);


            _hotel = new List<Hotel>
            {
                new Hotel
                {
                  Id = Guid.NewGuid(),
                  Name = "Studen kladenets-hotel",
                  PictureURL = "https://lh3.googleusercontent.com/p/AF1QipMHZMjQ3RzO4zeXWXeWsT_MUHbc2oO0MCZqcKQe=s294-w294-h220-n-k-no",
                  Location = "Studen kladenets",
                  Description = "The hotel have 25 rooms It is near to Lake and has resturant, swiming pool and many beautifull views.The rezervation for one people in this place is 2 days from 17.03.2024 to 19.03.2024 year.GSM FOR RESERVATION 088*********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  FreePlace = 24,
                  Price = 180,
                  FishingPlaceId = Guid.NewGuid(),
                },
                new Hotel
                {
                  Id = Guid.NewGuid(),
                  Name = "Stara Zagora - Hotel",
                  PictureURL = "https://lh3.googleusercontent.com/p/AF1QipORGURM7vRT8Ro6a9BEoCHeiotk2H6l3uh-9XHz=s184-w184-h144-n-k-no",
                  Location = "Stara Zagora",
                  Description = "The hotel have 35 rooms It is near to Lake and has resturant, swiming pool and many beautifull views.The rezervation for this place is 2 days from 25.03.2024 to 27.03.2024 year.GSM FOR RESERVATION 088**********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  FreePlace = 31,
                  Price = 250,
                  FishingPlaceId = Guid.NewGuid()
                }
            };

            _context.Hotels.AddRange(_hotel);
            _context.SaveChanges();

            _hotelService = new HotelServices(_context);
        }

        [Test]
        public async Task GetByIdAsync()
        {
      
            var hotelId = _hotel[0].Id;

            // Act
            var result = await _hotelService.GetByIdAsync(hotelId);

            // Assert
            Assert.AreEqual(hotelId, result.Id);
            Assert.AreEqual("Studen kladenets-hotel", result.Name);
        }
        [Test]
        public async Task GetByIdAsync1()
        {
            // Arrange
            var Id = Guid.NewGuid();

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _hotelService.GetByIdAsync(Id));
            Assert.AreEqual("There is no hotel", ex.Message);

        }
        [Test]
        public async Task ShowAllPlaceAsync()
        {
            // Act
            var result = await _hotelService.ShowAllPlaceAsync(0, 10);

            // Assert
            Assert.AreEqual(2, result.Count / 3);
        }
        [Test]
        public async Task DeleteHotelAsync()
        {
            // Arrange
            var hotel = _hotel[0];

            // Act
            await _hotelService.DeleteHotelAsync(hotel);

            // Assert
            Assert.IsTrue(hotel.IsDeleted);

        }
    }
}
