using FishingMania.Data.Interface;
using FishingMania.Models;
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
            var totalFishingPlaceCount = await this.hotels.GetFishingPlaceCountAsync();

            var fishingPlaces = await this.fishingPlaces.ShowAllPlaceAsync(skip, take);
            var totalPage = totalFishingPlaceCount / 3;
            var totalPages = totalFishingPlaceCount % 3;
            if (totalPages > 0)
            {
                totalPage++;
            }
            var Model = new FishingPlaceViewModelList
            {
                List = this.fishingPlaces.GetFishingPlacesViewModel(fishingPlaces),
                CurrentPage = currentPage,
                TotalPages = totalPage,
            };
            return View(Model);
        }
    }
}
