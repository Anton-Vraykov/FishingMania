
using FishingMania.Data;
using FishingMania.Data.Models;
using FishingMania.Models.HotelModels;
using FishingMania.Services.Data.Models.CarModels;
using Microsoft.EntityFrameworkCore;

namespace FishingMania.Services.Data.Interface_and_services.Cars
{
    public class CarServices:ICar
    {
        private readonly ApplicationDbContext db;
        public CarServices(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<Car>> ShowAllCarAsync(int skip, int take)
        {
            return await this.db.Cars.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }
        public int GetCarCountAsync() => this.db.Cars.Where(fp => !fp.IsDeleted).Count();
        public CarViewModel GetCarViewModel(Car car)
        {
            return new CarViewModel
            {
                Id = car.Id,
                Model = car.Model,
                PictureURL = car.PictureURL,
                Location = car.Location,
                FishingPlaceId = car.FishingPlaceId,
                Price = car.Price
            };
        }

    }
}
