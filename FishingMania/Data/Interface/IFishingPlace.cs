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
        FishingPlace GetById(int id);
        void Update(FishingPlace fishingPlace);
        void Delete(int Id, int password);
    }
}
