using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingMania.Data.Models
{
    public class ApplicationUserFishingPlace
    {
        public string ApplicationUserId { get; set; }=string.Empty;
        [ForeignKey(nameof(ApplicationUserId))]
        public virtual IdentityUser ApplicationUser { get; set; } = null!;

        public Guid FishingPlaceId { get; set; }
        [ForeignKey(nameof(FishingPlaceId))]
        public virtual FishingPlace FishingPlaces { get; set; } = null!;
    }
}
