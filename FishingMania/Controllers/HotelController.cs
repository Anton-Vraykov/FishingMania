using FishingMania.Data.Interface;
using FishingMania.Data.Models;
using FishingMania.Models;
using FishingMania.Models.HotelModels;
using FishingMania.Services.Data.Models.HotelModels;
using Microsoft.AspNetCore.Mvc;


namespace FishingMania.Controllers
{
    public class HotelController : BaseController
    {
        private readonly IHotel hotels;

        public HotelController(IHotel hotels)
        {

            this.hotels = hotels;

        }
        public async Task<IActionResult> Hotels(int currentPage = 1)
        {

            var skip = (currentPage - 1) * 3;
            var take = 3;
            var totalhotelsCount =  this.hotels.GetHotelCountAsync();

            var hotels = await this.hotels.ShowAllPlaceAsync(skip, take);
            var totalPage = totalhotelsCount / 3;
            var totalPages = totalhotelsCount % 3;
            if (totalPages > 0)
            {
                totalPage++;
            }
            var Model = new HotelViewModelList
            {
                List =this.hotels.GetHotelsViewModel(hotels),
                CurrentPage = currentPage,
                TotalPages = totalPage,
            };
            if (totalhotelsCount == 0)
            {
                return RedirectToAction(nameof(AddHotel));
            }
            return View(Model);
        }
        [HttpGet]
        public async Task<IActionResult> AddHotel(Guid Id)
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddHotel(AddHotelViewModel model,Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            string userId = GetUserId();
            await hotels.AddHotelAsync(model, userId,Id);
            return RedirectToAction(nameof(Hotels));
        }
    }
}
