using FishingMania.Data.Interface;
using FishingMania.Models.HotelModels;
using FishingMania.Services.Data.Models.HotelModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FishingMania.Common.ValidationConstant;


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
            var totalhotelsCount = this.hotels.GetHotelCountAsync();

            var hotels = await this.hotels.ShowAllPlaceAsync(skip, take);
            var totalPage = totalhotelsCount / 3;
            var totalPages = totalhotelsCount % 3;
            if (totalPages > 0)
            {
                totalPage++;
            }
            var Model = new HotelViewModelList
            {
                List = this.hotels.GetHotelsViewModel(hotels),
                CurrentPage = currentPage,
                TotalPages = totalPage,
            };
            //if (totalhotelsCount == 0)
            //{
            //    return RedirectToAction(nameof(AddHotel));
            //}
            return View(Model);
        }
        [Authorize(Roles = AdminRoleName)]
        [HttpGet]
        public async Task<IActionResult> AddHotel(Guid Id)
        {

            return  View();
        }
        [Authorize(Roles = AdminRoleName)]
        [HttpPost]
        public async Task<IActionResult> AddHotel(AddHotelViewModel model, Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = GetUserId();
            await hotels.AddHotelAsync(model, userId, Id);
            return RedirectToAction(nameof(Hotels));
        }
        [Authorize(Roles = AdminRoleName)]
        [HttpGet]
        public async Task<IActionResult> DetailHotel(Guid id)
        {
            HotelDetailViewModel model = await hotels.GetEditHotelModelAsync(id);

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
        [Authorize(Roles = AdminRoleName)]
        [HttpPost]
        public async Task<IActionResult> DetailHotel(Guid id, HotelDetailViewModel model)
        {
            var hotel = await hotels.GetByIdAsync(id);

            if (hotel == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (hotel.UserId != userId)
            {
                return Unauthorized();
            }

            await hotels.EditHotelAsync(model, hotel);

            return RedirectToAction(nameof(Hotels));
        }
        [Authorize(Roles = AdminRoleName)]
        [HttpGet]
        public async Task<IActionResult> DeleteHotel(Guid id)
        {
            var hotel = await hotels.GetByIdAsync(id);

            if (hotel == null)
            {
                return BadRequest();
            }

            DeleteHotelViewModel model = new DeleteHotelViewModel
            {
                Id = hotel.Id,
                Name = hotel.Name
            };

            return View(model);
        }
        [Authorize(Roles = AdminRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, DeleteHotelViewModel model)
        {
            var fp = await hotels.GetByIdAsync(id);

            if (fp == null)
            {
                return BadRequest();
            }

            await hotels.DeleteHotelAsync(fp);

            return RedirectToAction(nameof(Hotels));
        }
    }
}
