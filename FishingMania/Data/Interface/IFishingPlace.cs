using FishingMania.Data.Models;
using FishingMania.Data.Services;

namespace FishingMania.Data.Interface
{
    public interface IFishingPlace
    {
        List<FishingPlace> ShowAllPlace(int skip, int take);
        int GetFishingPlaceCount();
        void Add(FishingPlace fishingPlace);
        FishingPlace GetById(int id);
        void Update(FishingPlace fishingPlace);
        void Delete(int Id, int password);
    }
}
