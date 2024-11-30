

namespace FishingMania.Services.Data.Models.EventModels
{
    public class EventViewModelList
    {
        public List<EventViewModel> List { get; set; } = new List<EventViewModel>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
