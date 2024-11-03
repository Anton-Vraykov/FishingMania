using FishingMania.Data.Interface;
using FishingMania.Data.Models;
using FishingMania.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace FishingMania.Data.Services
{
    public class FishingPlaceServices : IFishingPlace
    {
        private readonly ApplicationDbContext db;
        public FishingPlaceServices(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task AddPlaceAsync(AddPlaceViewModel place, string userId)
        {
          
            var placeData = new FishingPlace
            {
                Name = place.Name,
                Description = place.Description,
                PictureURL = place.PictureURL,
                UserId = userId,
                TypeFishingId=place.TypeFishingId,
                CarId = place.CarId,
                EventId = place.EventId,
                HotelId = place.HotelId
                

            };

            await db.FishingPlaces.AddAsync(placeData);
            await db.SaveChangesAsync();
        }


        public void Delete(int Id, int password)
        {
            throw new NotImplementedException();
        }

        public FishingPlace GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetFishingPlaceCount() => this.db.FishingPlaces.Where(fp => !fp.IsDeleted).Count();


        public List<FishingPlace> ShowAllPlace(int skip, int take)
        {
            return this.db.FishingPlaces.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToList();
        }

        public void Update(FishingPlace fishingPlace)
        {
            throw new NotImplementedException();
        }
        public async Task<AddPlaceViewModel> GetAddModelAsync()
        {
            var fishingTypes = await db.TypesFishings
                .Select(g => new FishingTypeViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();

            var model = new AddPlaceViewModel
            {
                FishingTypes = fishingTypes
            };

            return model;
        }

    }
}
