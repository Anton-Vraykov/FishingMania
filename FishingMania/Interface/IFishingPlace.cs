using FishingMania.Data.Models;
using FishingMania.Models;


namespace FishingMania.Data.Interface
{
    public interface IFishingPlace
    {
        Task<List<FishingPlace>> ShowAllPlaceAsync(int skip, int take);
        Task<int> GetFishingPlaceCountAsync();
        Task AddPlaceAsync(AddPlaceViewModel place, string userId);
        Task<AddPlaceViewModel> GetAddModelAsync();
        Task<FishingPlace> GetByIdAsync(Guid id);
        Task<DetailViewModel> GetEditModelAsync(Guid id);
        Task EditFishingPlaceAsync(DetailViewModel model, FishingPlace fishingPlace);
        Task DeleteFishingPlaceAsync(FishingPlace fishingPlace);
    }
}
