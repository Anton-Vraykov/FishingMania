namespace FishingMania.Models.HotelModels
{
    public class HotelViewModelList
    {

        public List<HotelViewModel> List { get; set; } = new List<HotelViewModel>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
