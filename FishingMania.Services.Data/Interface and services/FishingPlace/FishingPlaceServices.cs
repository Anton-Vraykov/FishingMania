using FishingMania.Data.Interface;
using Microsoft.EntityFrameworkCore;
using FishingMania.Data.Models;
using FishingMania.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.CSharp.Syntax;




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
            FishingPlace? model =  this.db.FishingPlaces.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == id);
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
        public FishingPlaceViewModel GetFishingPlaceViewModel(FishingPlace f)
        {
            return new FishingPlaceViewModel
            {
                Id = f.Id,
                Name = f.Name,
                PictureURL = f.PictureURL,
                Location = f.Location,
                Description = f.Description,
                UserId = f.UserId,
                TypeFishingId = f.TypeFishingId

            };
        }
        public List<FishingPlaceViewModel> GetFishingPlacesViewModel(List<FishingPlace> source)
        {
            var fishingPlaces = new List<FishingPlaceViewModel>();


            foreach (var f in source)
            {
                fishingPlaces.Add(GetFishingPlaceViewModel(f));
            }

            return fishingPlaces;
        }
        public FishingPlace GetFishingPlaceDataModel(AddPlaceViewModel fishingPlace)
        {
            return new FishingPlace
            {
                Id = fishingPlace.Id,
                Name = fishingPlace.Name,
                PictureURL = fishingPlace.PictureURL,
                Location = fishingPlace.Location,
                Description = fishingPlace.Description,
                TypeFishingId = fishingPlace.TypeFishingId,

            };
        }

      
    }
}
