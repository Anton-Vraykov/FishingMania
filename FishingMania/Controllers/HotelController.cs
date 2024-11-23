using FishingMania.Data.Interface;
using FishingMania.Models.HotelModels;
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
            return View(Model);
        }
    }
}
