

using FishingMania.Data;
using FishingMania.Data.Interface;
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
            return await this.db.Hotels.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }
    }
}
