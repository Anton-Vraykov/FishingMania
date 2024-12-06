using FishingMania.Services.Data.Interface_and_services.Events;
using FishingMania.Services.Data.Models.EventModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FishingMania.Common.ValidationConstant;

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
            //if (totalCarsCount == 0)
            //{
            //    return RedirectToAction(nameof(AddEvent));
            //}
            return View(Model);


        }
        [Authorize(Roles = AdminRoleName)]
        [HttpGet]
        public async Task<IActionResult> AddEvent(Guid Id)
        {

            return View();
        }
        [Authorize(Roles = AdminRoleName)]
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
        [Authorize(Roles = AdminRoleName)]
        [HttpGet]
        public async Task<IActionResult> DetailsEvent(Guid id)
        {
            EventDetailViewModel model = await events.GetEditEventModelAsync(id);

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
        public async Task<IActionResult> DetailsEvent(Guid id, EventDetailViewModel model)
        {
            var even = await events.GetByIdAsync(id);

            if (even == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (even.UserId != userId)
            {
                return Unauthorized();
            }

            await events.EditEventAsync(model, even);

            return RedirectToAction(nameof(Events));
        }
        [Authorize(Roles = AdminRoleName)]
        [HttpGet]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var even = await events.GetByIdAsync(id);

            if (even == null)
            {
                return BadRequest();
            }

            DeleteEventViewModel model = new DeleteEventViewModel
            {
                Id = even.Id,
                Name = even.Name
            };

            return View(model);
        }
        [Authorize(Roles = AdminRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, DeleteEventViewModel model)
        {
            var fp = await events.GetByIdAsync(id);

            if (fp == null)
            {
                return BadRequest();
            }

            await events.DeleteEventAsync(fp);

            return RedirectToAction(nameof(Events));
        }
    }
}
