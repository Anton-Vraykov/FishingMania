using FishingMania.Data.Models;
using FishingMania.Data.Services;
using FishingMania.Models;

namespace FishingMania.Data.Interface
{
    public interface IFishingPlace
    {
        List<FishingPlace> ShowAllPlace(int skip, int take);
        int GetFishingPlaceCount();
        Task AddPlaceAsync(AddPlaceViewModel place, string userId);
        Task<AddPlaceViewModel> GetAddModelAsync();
        Task<FishingPlace> GetById(Guid id);
        Task<DetailViewModel> GetEditModelAsync(Guid id);
        Task EditFishingPlaceAsync(DetailViewModel model, FishingPlace fishingPlace);
        Task DeleteFishingPlaceAsync(FishingPlace fishingPlace);
    }
}
