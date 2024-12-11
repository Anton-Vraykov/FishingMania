

using FishingMania.Data.Models;
using FishingMania.Services.Data.Models.CarModels;
using FishingMania.Services.Data.Models.HotelModels;


namespace FishingMania.Services.Data.Interface_and_services.Cars
{
    public interface ICar
    {
        Task<List<Car>> ShowAllCarAsync(int skip, int take, Guid Id);
        public int GetCarCountAsync();
        List<CarViewModel> GetCarsViewModel(List<Car> source);
        CarViewModel GetCarViewModel(Car car);
        Task AddCarAsync(AddCarViewModel car, string userId, Guid Id);
        Task<CarDetailViewModel> GetEditCarModelAsync(Guid id);
        Task<Car> GetByIdAsync(Guid id);
        Task EditCarAsync(CarDetailViewModel model, Car car);
        Task DeleteCarAsync(Car car);
    }
}
