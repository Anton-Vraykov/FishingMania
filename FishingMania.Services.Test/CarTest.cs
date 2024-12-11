
using FishingMania.Data.Models;
using FishingMania.Data;
using Microsoft.EntityFrameworkCore;
using FishingMania.Services.Data.Interface_and_services.Cars;

namespace FishingMania.Services.Test
{
    public class CarTest
    {
        
        private ICar carService;
        private List<Car> car;


        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("FishingManiaTestDb")
                .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);


            car = new List<Car>
            {
                new Car
                {
                  Id = Guid.NewGuid(),
                  Model = "Volvo XC60",
                  PictureURL = "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg",
                  Location = "Studen kladenets",
                  Details = "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags..The rezervation for this car for 3 days from 17.03.2024 to 19.03.2024 year.GSM FOR RESERVATION 088*********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  AvelableCars = 21,
                  Price = 180,
                  FishingPlaceId = Guid.NewGuid()
                },
                new Car
                {
                  Id = Guid.NewGuid(),
                  Model = "Volvo XC60",
                  PictureURL = "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg",
                  Location = "Stara Zagora",
                  Details = "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags.The rezervation for car is 3 days from 25.03.2024 to 27.03.2024 year.GSM FOR RESERVATION 088**********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  AvelableCars = 21,
                  Price = 180,
                  FishingPlaceId = Guid.NewGuid()
                }
            };

            context.Cars.AddRange(car);
            context.SaveChanges();

            carService = new CarServices(context);
        }

        [Test]
        public async Task GetByIdAsync()
        {
            
            var carId = car[0].Id;

            
            var result = await carService.GetByIdAsync(carId);

            
            Assert.AreEqual(carId, result.Id);
            Assert.AreEqual("Volvo XC60", result.Model);
        }
        [Test]
        public async Task GetByIdAsync1()
        {
          
            var Id = Guid.NewGuid();

            
            var ex = Assert.ThrowsAsync<Exception>(() => carService.GetByIdAsync(Id));
            Assert.AreEqual("There is no car", ex.Message);

        }
        [Test]
        public async Task ShowAllPlaceAsync()
        {
           
            var result = await carService.ShowAllCarAsync(0, 10);

            
            Assert.AreEqual(2, result.Count / 3);
        }
        [Test]
        public async Task DeleteHotelAsync()
        {
            
            var car = this.car[0];

          
            await carService.DeleteCarAsync(car);

            
            Assert.IsTrue(car.IsDeleted);

        }
    }
}
