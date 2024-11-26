using FishingMania.Data.Interface;
using FishingMania.Models.HotelModels;
using FishingMania.Services.Data.Interface_and_services.Cars;
using FishingMania.Services.Data.Models.CarModels;
using Microsoft.AspNetCore.Mvc;

namespace FishingMania.Controllers
{
    public class CarController : Controller
    {
        private readonly ICar cars;

        public CarController(ICar cars)
        {

            this.cars = cars;

        }
        public async Task<IActionResult> Cars(int currentPage = 1)
        {

            var skip = (currentPage - 1) * 3;
            var take = 3;
            var totalCarsCount = this.cars.GetCarCountAsync();

            var cars = await this.cars.ShowAllCarAsync(skip, take);
            var totalPage = totalhotelsCount / 3;
            var totalPages = totalhotelsCount % 3;
            if (totalPages > 0)
            {
                totalPage++;
            }
            var Model = new CarViewModelList
            {
                List = this.cars.GetCarViewModel(cars),
                CurrentPage = currentPage,
                TotalPages = totalPage,
            };
            if (totalCarsCount == 0)
            {
                return RedirectToAction(nameof(AddCar));
            }
            return View(Model);
        }
    }
}
