

using FishingMania.Data.Models;
using FishingMania.Models.HotelModels;
using FishingMania.Services.Data.Models.CarModels;
using FishingMania.Services.Data.Models.HotelModels;

namespace FishingMania.Services.Data.Interface_and_services.Cars
{
    public interface ICar
    {
        Task<List<Car>> ShowAllCarAsync(int skip, int take);
        public int GetCarCountAsync();
        List<CarViewModel> GetCarViewModel(List<Car> source);
        CarViewModel GetCarViewModel(Car car);
        Task AddCarAsync(AddCarViewModel car, string userId, Guid Id);
    }
}
