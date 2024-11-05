﻿using FishingMania.Data.Interface;
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
             

            };

            await db.FishingPlaces.AddAsync(placeData);
            await db.SaveChangesAsync();
        }


        public void Delete(int Id, int password)
        {
            throw new NotImplementedException();
        }

        public async Task<FishingPlace> GetById(Guid id)
        {
            FishingPlace model= this.db.FishingPlaces.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                throw new Exception("There is no FishingPlace");
            }
            return  model;
        }

        public int GetFishingPlaceCount() => this.db.FishingPlaces.Where(fp => !fp.IsDeleted).Count();


        public List<FishingPlace> ShowAllPlace(int skip, int take)
        {
            return this.db.FishingPlaces.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToList();
        }

        public async void Update(FishingPlace fishingPlace)
        {
           

            var fishingPlaceToUpdate = await this.db.FishingPlaces.FirstOrDefaultAsync(x => x.Id == fishingPlace.Id);
            if (fishingPlaceToUpdate == null) { return; }


            fishingPlaceToUpdate.Name = fishingPlace.Name;
            fishingPlaceToUpdate.Description = fishingPlace.Description;
            fishingPlaceToUpdate.Location = fishingPlace.Location;
            fishingPlaceToUpdate.PictureURL = fishingPlace.PictureURL;
          

            await this.db.SaveChangesAsync();

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
