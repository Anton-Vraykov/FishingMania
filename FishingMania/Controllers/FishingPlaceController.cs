using FishingMania.Data.Interface;
using FishingMania.Data.Models;
using FishingMania.Data.Services;
using FishingMania.Models;
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

        public IActionResult FishingPlace(int currentPage=1)
        {

            var skip = (currentPage - 1) * 3;
            var take = 3;
            var totalFishingPlaceCount = this.fishingPlaces.GetFishingPlaceCount();

            var fishingPlaces = this.fishingPlaces.ShowAllPlace(skip, take);
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

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

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
                UserId=f.UserId


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
    }
}
