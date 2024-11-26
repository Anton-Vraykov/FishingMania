

namespace FishingMania.Services.Data.Models.CarModels
{
    public class CarViewModelList
    {
        public List<CarViewModel> List { get; set; } = new List<CarViewModel>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
