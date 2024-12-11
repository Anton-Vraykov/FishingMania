using Microsoft.EntityFrameworkCore;
using FishingMania.Data;
using FishingMania.Data.Models;
using FishingMania.Services.Data.Models.FishingPlaceModels;
using FishingMania.Data.Interface;
using Moq;

namespace FishingMania.Services.Test
{
    [TestFixture]
    public class FishingPlaceServicesTests
    {
       
        private IFishingPlace fishingPlaceService;
        private List<FishingPlace> fishingPlaces;
        

        [SetUp]
        public void Setup()
        {
           
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("FishingManiaTestDb")
                .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

           
            fishingPlaces = new List<FishingPlace>
            {
                new FishingPlace
                {
                   Id = Guid.NewGuid(),
                   Name = "Studen kladenets",
                   PictureURL = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/467694130.jpg?k=694e5ed2ad33b65f2e3d3c34e5016b7d853416e0b8502bd5569db2d32c4fb8e5&o=",
                   Location = "Studen kladenets",
                   Description = "Studen kladenets (Cold well) is a reservoir in Eastern Rhodope Mountains, built on Arda river. It is part of a huge Communist project, implemented in the 1960-s, when many rivers in Bulgaria were damed, the flow of water obstructed with few villages stayed under water. The Arda project involves three big reservoirs and it is announced “Arda Cascade”.  Studen kladenets is in the middle.The rezervation for fishing in this place is 3 days from 17.03.2024 to 19.03.2024 year.GSM FOR RESERVATION 088*********",
                   UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                   TypeFishingId = Guid.NewGuid(),
                   IsDeleted = false
                },
                new FishingPlace
                {
                    Id = Guid.NewGuid(),
                   Name = "Stara Zagora - Lake",
                   PictureURL = "https://media-cdn.tripadvisor.com/media/photo-s/0d/d5/96/49/park-hotel-stara-zagora.jpg",
                   Location = "Stara Zagora",
                   Description = "Zagorka Lake is a stunning park located in the heart of Stara Zagora, providing a peaceful retreat for both locals and tourists alike. As you enter the park, you are greeted by the shimmering waters of the lake, surrounded by lush greenery and vibrant flower beds that change with the seasons. The sound of birds chirping and the gentle rustling of leaves create a serene atmosphere, making it a perfect escape from the hustle and bustle of city life.The rezervation for fishing in this place is 3 days from 25.03.2024 to 27.03.2024 year.GSM FOR RESERVATION 088**********",
                   UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                   TypeFishingId = Guid.NewGuid(),
                   IsDeleted = false
                }
            };

            context.FishingPlaces.AddRange(fishingPlaces);
            context.SaveChanges();

            fishingPlaceService = new FishingPlaceServices(context);
        }

        [Test]
        public async Task GetByIdAsync()
        {
           
            var fishingPlaceId = fishingPlaces[0].Id;

            
            var result = await fishingPlaceService.GetByIdAsync(fishingPlaceId);

            
            Assert.AreEqual(fishingPlaceId, result.Id);
            Assert.AreEqual("Studen kladenets", result.Name);
        }
        [Test]
        public async Task GetByIdAsync1()
        {
           
            var Id = Guid.NewGuid();

           
            var ex = Assert.ThrowsAsync<Exception>(() => fishingPlaceService.GetByIdAsync(Id));
            Assert.AreEqual("There is no FishingPlace", ex.Message);
            
        }
        [Test]
        public async Task ShowAllPlaceAsync()
        {
           
            var result = await fishingPlaceService.ShowAllPlaceAsync(0, 10);

            
            Assert.AreEqual(2, result.Count/3);
        }
        [Test]
        public async Task DeleteFishingPlaceAsync()
        {
            
            var fishingPlace = fishingPlaces[0];

           
            await fishingPlaceService.DeleteFishingPlaceAsync(fishingPlace);

           
            Assert.IsTrue(fishingPlace.IsDeleted);
            
        }
        


    }
}
