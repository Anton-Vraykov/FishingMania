

using FishingMania.Data.Models;
using FishingMania.Models.HotelModels;
using FishingMania.Services.Data.Models.CarModels;

namespace FishingMania.Services.Data.Interface_and_services.Cars
{
    public interface ICar
    {
        Task<List<Car>> ShowAllCarAsync(int skip, int take);
        public int GetCarCountAsync();
        List<CarViewModel> GetHotelsViewModel(List<Car> source);
    }
}
