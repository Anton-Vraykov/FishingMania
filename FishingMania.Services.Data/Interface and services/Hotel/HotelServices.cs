

using FishingMania.Data;
using FishingMania.Data.Interface;
using FishingMania.Data.Models;
using FishingMania.Models;
using FishingMania.Models.HotelModels;
using Microsoft.EntityFrameworkCore;

namespace FishingMania.Services.Data.Interface_and_services.Hotel
{
    public class HotelServices : IHotel
    {
        private readonly ApplicationDbContext db;
        public HotelServices(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Task<List<FishingMania.Data.Models.Hotel>> ShowAllPlaceAsync(int skip, int take)
        {
           return  this.db.Hotels.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }
        public async Task<int> GetHotelCountAsync() => await this.db.Hotels.Where(fp => !fp.IsDeleted).CountAsync();

        public HotelViewModel GetHotelViewModel(FishingMania.Data.Models.Hotel h)
        {
            return new HotelViewModel
            {
                Id = h.Id,
                Name = h.Name,
                PictureURL = h.PictureURL,
                Location = h.Location,
                Description = h.Description,
                

            };
        }
        public List<HotelViewModel> GetHotelsViewModel(List<FishingMania.Data.Models.Hotel> source)
        {
            var hotel = new List<HotelViewModel>();


            foreach (var f in source)
            {
                hotel.Add(GetFishingPlaceViewModel(f));
            }

            return hotel;
        }
    }
}
