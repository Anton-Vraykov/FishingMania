
using FishingMania.Data;
using FishingMania.Data.Models;
using FishingMania.Models.HotelModels;
using FishingMania.Services.Data.Models.CarModels;
using FishingMania.Services.Data.Models.HotelModels;
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
                AvelableCars = car.AvelableCars,
                Price = car.Price
            };
        }

        public List<CarViewModel> GetCarViewModel(List<Car> source)
        {
            var cars = new List<CarViewModel>();


            foreach (var car in source)
            {
                cars.Add(GetCarViewModel(car));
            }

            return cars;
        }
        public async Task AddCarAsync(AddCarViewModel car, string userId, Guid Id)
        {

            if (car.Price < 0)
            {
                return;
            }
            var carData = new Car
            {

                Model = car.Model,
                Details = car.Details,
                PictureURL = car.PictureURL,
                Location = car.Location,
                UserId = userId,
                Price = car.Price,
                AvelableCars = car.AvelableCars,
                FishingPlaceId = Id

            };
            await db.Cars.AddAsync(carData);
            await db.SaveChangesAsync();
        }
    }
}
