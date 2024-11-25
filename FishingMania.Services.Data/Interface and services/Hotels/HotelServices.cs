

using FishingMania.Data;
using FishingMania.Data.Interface;
using FishingMania.Data.Models;
using FishingMania.Models;
using FishingMania.Models.HotelModels;
using FishingMania.Services.Data.Models.HotelModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace FishingMania.Services.Data.Interface_and_services.Hotels
{
    public class HotelServices : IHotel
    {
        private readonly ApplicationDbContext db;
        public HotelServices(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<Hotel>> ShowAllPlaceAsync(int skip, int take)
        {
           return await this.db.Hotels.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }
        public int GetHotelCountAsync() => this.db.Hotels.Where(fp => !fp.IsDeleted).Count();

        public HotelViewModel GetHotelViewModel(Hotel h)
        {
            return new HotelViewModel
            {
                Id = h.Id,
                Name = h.Name,
                PictureURL = h.PictureURL,
                Location = h.Location,
                Description = h.Description,
                FreePlace = h.FreePlace,
                Price= h.Price
            };
        }
        public List<HotelViewModel> GetHotelsViewModel(List<Hotel> source)
        {
            var hotel = new List<HotelViewModel>();


            foreach (var f in source)
            {
                hotel.Add(GetHotelViewModel(f));
            }

            return hotel;
        }
        
       
        public async Task AddHotelAsync(AddHotelViewModel place, string userId, Guid Id)
        {
            
            if (place.Price < 0)
            {
                return;
            }
            var placeData = new Hotel
            {
               
                Name = place.Name,
                Description = place.Description,
                PictureURL = place.PictureURL,
                Location = place.Location,
                UserId=userId,
                Price = place.Price,
                FreePlace= place.FreePlace,
                FishingPlaceId=Id
               


            };


            await db.Hotels.AddAsync(placeData);
            await db.SaveChangesAsync();
        }
        public async Task<HotelDetailViewModel> GetEditHotelModelAsync(Guid id)
        {
            

            var hotel = await db.Hotels
                .Where(g => g.Id == id)
                .Select(g => new HotelDetailViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Location = g.Location,
                    Description = g.Description,
                    PictureURL = g.PictureURL,
                    Price=g.Price,
                    FreePlace= g.FreePlace,
                    FishingPlaceId=g.FishingPlaceId,
                    UserId = g.UserId
                })
                .FirstOrDefaultAsync();

            return hotel;
        }

        public async Task<Hotel> GetByIdAsync(Guid id)
        {
            var hotel= await db.Hotels.Where(h=>h.IsDeleted == false).FirstOrDefaultAsync(h=>h.Id==id);
            if (hotel == null)
            {
                throw new ArgumentException("There is no hotel ");
            }
            return hotel;
        }
        public async Task EditHotelAsync(HotelDetailViewModel model, Hotel hotel)
        {
            hotel.Id = model.Id;
            hotel.Name = model.Name;
            hotel.Location = model.Location;
            hotel.Description = model.Description;
            hotel.PictureURL = model.PictureURL;
            hotel.FreePlace = model.FreePlace;
            hotel.Price = model.Price;


            await db.SaveChangesAsync();
        }
        public async Task DeleteHotelAsync(Hotel hotel)
        {


            if (hotel.IsDeleted != true)
            {
                hotel.IsDeleted = true;
                await db.SaveChangesAsync();
            }
            else
            {
                return;
            }



        }
    }
}
