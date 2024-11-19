
using FishingMania.Data.Interface;
using FishingMania.Data.Models;
using FishingMania.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace FishingMania.Controllers
{
    public class FishingPlaceController : BaseController
    {
       
        private readonly IFishingPlace fishingPlaces;

        public FishingPlaceController( IFishingPlace fishingPlaces)
        {
          
            this.fishingPlaces = fishingPlaces;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FishingPlace(int currentPage=1)
        {

            var skip = (currentPage - 1) * 3;
            var take = 3;
            var totalFishingPlaceCount = await this.fishingPlaces.GetFishingPlaceCountAsync();

            var fishingPlaces = await this.fishingPlaces.ShowAllPlaceAsync(skip, take);
            var totalPage = totalFishingPlaceCount / 3;
            var totalPages = totalFishingPlaceCount % 3;
            if (totalPages > 0)
            {
                totalPage++;
            }
            var Model = new FishingPlaceViewModelList
            {
                List = GetFishingPlacesViewModel(fishingPlaces),
                CurrentPage = currentPage,
                TotalPages = totalPage,
            };
            return View(Model);
        }
        [HttpGet]
        public async Task<IActionResult> AddFishingPlace()
        {
            AddPlaceViewModel model = await fishingPlaces.GetAddModelAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddFishingPlace(AddPlaceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = GetUserId();
            await fishingPlaces.AddPlaceAsync(model, userId);
            return RedirectToAction(nameof(FishingPlace));
        }
        [HttpGet]
        public async Task<IActionResult> DetailsPlace(Guid id)
        {
            DetailViewModel model = await fishingPlaces.GetEditModelAsync(id);

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
        public async Task<IActionResult> DetailsPlace(Guid id, DetailViewModel model)
        {
            var fishingPlace = await fishingPlaces.GetByIdAsync(id);

            if (fishingPlace == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (fishingPlace.UserId != userId)
            {
                return Unauthorized();
            }

            await fishingPlaces.EditFishingPlaceAsync(model, fishingPlace);

            return RedirectToAction(nameof(FishingPlace));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var fp= await fishingPlaces.GetByIdAsync(id);

            if (fp == null)
            {
                return BadRequest();
            }

            DeleteViewModel model = new DeleteViewModel
            {
                Id = fp.Id,
                Name = fp.Name
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, DeleteViewModel model)
        {
            var fp = await fishingPlaces.GetByIdAsync(id);

            if (fp == null)
            {
                return BadRequest();
            }

            await fishingPlaces.DeleteFishingPlaceAsync(fp);

            return RedirectToAction(nameof(FishingPlace));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private FishingPlaceViewModel GetFishingPlaceViewModel(FishingPlace f)
        {
            return new FishingPlaceViewModel
            {
                Id = f.Id,
                Name = f.Name,
                PictureURL = f.PictureURL,
                Location = f.Location,
                Description = f.Description,
                UserId=f.UserId,
                TypeFishingId = f.TypeFishingId
               
                
                
            };
        }
    
        private List<FishingPlaceViewModel> GetFishingPlacesViewModel(List<FishingPlace> source)
        {
            var fishingPlaces = new List<FishingPlaceViewModel>();


            foreach (var f in source)
            {
                fishingPlaces.Add(GetFishingPlaceViewModel(f));
            }

            return fishingPlaces;
        }
        private FishingPlace GetFishingPlaceDataModel(AddPlaceViewModel fishingPlace)
        {
            return new FishingPlace
            {
                Id=fishingPlace.Id,
                Name = fishingPlace.Name,
                PictureURL = fishingPlace.PictureURL,
                Location = fishingPlace.Location,
                Description = fishingPlace.Description,
                TypeFishingId = fishingPlace.TypeFishingId,
                
            };
        }

    }
}
