using FishingMania.Data.Models;
using FishingMania.Models;

namespace FishingMania.Data.Interface
{
    public interface IHotel
    {
        Task<List<Hotel>> ShowAllPlaceAsync(int skip, int take);
    }
}
