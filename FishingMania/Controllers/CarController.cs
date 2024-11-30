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
                List = this.cars.GetCarsViewModel(cars),
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
        public async Task<IActionResult> AddCar(AddCarViewModel models, Guid Id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(models);
            //}

            string userId = GetUserId();
            await cars.AddCarAsync(models, userId, Id);
            return RedirectToAction(nameof(Cars));
        }
        [HttpGet]
        public async Task<IActionResult> DetailCar(Guid id)
        {
            CarDetailViewModel model = await cars.GetEditCarModelAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (model.UserId != userId)
            {
                return Unauthorized();
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DetailCar(Guid id, CarDetailViewModel carmodel)
        {
            var car = await cars.GetByIdAsync(id);

            if (car == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (car.UserId != userId)
            {
                return Unauthorized();
            }

            await cars.EditCarAsync(carmodel, car);

            return RedirectToAction(nameof(Cars));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            var car = await cars.GetByIdAsync(id);

            if (car == null)
            {
                return BadRequest();
            }

            DeleteCarViewModel model = new DeleteCarViewModel
            {
                Id = car.Id,
                Model = car.Model
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, DeleteCarViewModel model)
        {
            var cs = await cars.GetByIdAsync(id);

            if (cs == null)
            {
                return BadRequest();
            }

            await cars.DeleteCarAsync(cs);

            return RedirectToAction(nameof(Cars));
        }
    }
}
