namespace FishingMania.Models
{
    public class FishingPlaceViewModelList
    {
        public List<FishingPlaceViewModel> List { get; set; }=new List<FishingPlaceViewModel>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
