using FishingMania.Data.Interface;
using FishingMania.Data.Models;
using FishingMania.Models.HotelModels;
using FishingMania.Services.Data.Interface_and_services.Cars;
using FishingMania.Services.Data.Models.CarModels;
using FishingMania.Services.Data.Models.HotelModels;
using Microsoft.AspNetCore.Mvc;

namespace FishingMania.Controllers
{
    public class CarController : BaseController
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
            var totalPage = totalCarsCount / 3;
            var totalPages = totalCarsCount % 3;
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
        [HttpGet]
        public async Task<IActionResult> AddCar(Guid Id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCar(AddCarViewModel model, Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = GetUserId();
            await cars.AddCarAsync(model, userId, Id);
            return RedirectToAction(nameof(Cars));
        }
    }
}
