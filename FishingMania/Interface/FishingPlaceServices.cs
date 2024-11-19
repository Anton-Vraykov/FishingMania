using FishingMania.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using FishingMania.Data.Models;
using FishingMania.Models;




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
                Location = place.Location,
                TypeFishingId = place.TypeFishingId,


            };

            await db.FishingPlaces.AddAsync(placeData);
            await db.SaveChangesAsync();
        }


        public async Task<FishingPlace> GetByIdAsync(Guid id)
        {
            FishingPlace model = this.db.FishingPlaces.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                throw new Exception("There is no FishingPlace");
            }
            return model;
        }

        public async Task<int> GetFishingPlaceCountAsync() =>await this.db.FishingPlaces.Where(fp => !fp.IsDeleted).CountAsync();


        public async Task<List<FishingPlace>> ShowAllPlaceAsync(int skip, int take)
        {
            return await this.db.FishingPlaces.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToListAsync();
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

        public async Task<DetailViewModel> GetEditModelAsync(Guid id)
        {
            var fishingTypes = await db.TypesFishings
                .Select(g => new FishingTypeViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();

            var fishingPlace = await db.FishingPlaces
                .Where(g => g.Id == id)
                .Select(g => new DetailViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Location=g.Location,
                    Description = g.Description,
                    PictureURL = g.PictureURL,
                    TypeFishingId = g.TypeFishingId,
                    FishingTypes = fishingTypes,
                    UserId = g. UserId
                })
                .FirstOrDefaultAsync();
            ;

            return fishingPlace;
        }
        public async Task EditFishingPlaceAsync(DetailViewModel model, FishingPlace fishingPlace)
        {
            fishingPlace.Id = model.Id;
            fishingPlace.Name = model.Name;
            fishingPlace.Location = model.Location;
            fishingPlace.Description = model.Description;
            fishingPlace.PictureURL = model.PictureURL;
            fishingPlace.TypeFishingId = model.TypeFishingId;

            await db.SaveChangesAsync();
        }
        public async Task DeleteFishingPlaceAsync(FishingPlace fishingPlace)
        {
            
            
            if (fishingPlace.IsDeleted != true) 
            {
                fishingPlace.IsDeleted = true;
                await db.SaveChangesAsync();
            }
            else
            {
                return;
            }

            
           
        }
        
    }
}
