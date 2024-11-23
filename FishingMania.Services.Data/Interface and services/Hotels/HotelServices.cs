

using FishingMania.Data;
using FishingMania.Data.Interface;
using FishingMania.Data.Models;
using FishingMania.Models.HotelModels;
using Microsoft.EntityFrameworkCore;


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
        public int GetHotelCountAsync() =>  this.db.Hotels.Where(fp => !fp.IsDeleted).Count();

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
    }
}
