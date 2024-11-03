using FishingMania.Data.Interface;
using FishingMania.Data.Models;

namespace FishingMania.Data.Services
{
    public class FishingPlaceServices : IFishingPlace
    {
        private readonly ApplicationDbContext db;
        public FishingPlaceServices(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(FishingPlace fishingPlace)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id, int password)
        {
            throw new NotImplementedException();
        }

        public FishingPlace GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetFishingPlaceCount() => this.db.FishingPlaces.Where(fp => !fp.IsDeleted).Count();


        public List<FishingPlace> ShowAllPlace(int skip, int take)
        {
            return this.db.FishingPlaces.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToList();
        }

        public void Update(FishingPlace fishingPlace)
        {
            throw new NotImplementedException();
        }

    }
}
