using FishingMania.Services.Data.Interface_and_services.Events;
using FishingMania.Services.Data.Models.CarModels;
using FishingMania.Services.Data.Models.EventModels;
using FishingMania.Services.Data.Models.HotelModels;
using Microsoft.AspNetCore.Mvc;

namespace FishingMania.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEvent events;
       
        public EventController(IEvent events)
        {
            this.events = events;
        }
        public async Task<IActionResult> Events(int currentPage = 1)
        {

            var skip = (currentPage - 1) * 3;
            var take = 3;
            var totalCarsCount = this.events.GetEventCountAsync();

            var events = await this.events.ShowAllPlaceAsync(skip, take);
            var totalPage = totalCarsCount / 3;
            var totalPages = totalCarsCount % 3;
            if (totalPages > 0)
            {
                totalPage++;
            }
            var Model = new EventViewModelList
            {
                List = this.events.GetEventsViewModel(events),
                CurrentPage = currentPage,
                TotalPages = totalPage,
            };
            if (totalCarsCount == 0)
            {
                return RedirectToAction(nameof(AddEvent));
            }
            return View(Model);


        }
        [HttpGet]
        public async Task<IActionResult> AddEvent(Guid Id)
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEvent(AddEventViewModel model, Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = GetUserId();
            await events.AddEventAsync(model, userId, Id);
            return RedirectToAction(nameof(Events));
        }
        //[HttpGet]
        //public async Task<IActionResult> DetailEvent(Guid id)
        //{
        //    EventDetailViewModel model = await events.GetEditEventModelAsync(id);

        //    if (model == null)
        //    {
        //        return BadRequest();
        //    }

        //    string userId = GetUserId();

        //    if (model.UserId != userId)
        //    {
        //        return Unauthorized();
        //    }

        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> DetailHotel(Guid id, HotelDetailViewModel model)
        //{
        //    var hotel = await hotels.GetByIdAsync(id);

        //    if (hotel == null)
        //    {
        //        return BadRequest();
        //    }

        //    string userId = GetUserId();

        //    if (hotel.UserId != userId)
        //    {
        //        return Unauthorized();
        //    }

        //    await hotels.EditHotelAsync(model, hotel);

        //    return RedirectToAction(nameof(Hotels));
        //}
    }
}
