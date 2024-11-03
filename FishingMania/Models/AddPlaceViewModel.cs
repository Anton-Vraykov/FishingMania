using FishingMania.Common;
using System.ComponentModel.DataAnnotations;

namespace FishingMania.Models
{
    public class AddPlaceViewModel
    {
        public string Name { get; set; } = string.Empty;
        [Required]
        public string PictureURL { get; set; } = string.Empty;
        [Required]
        [MaxLength(ValidationConstant.PlaceLocationMax)]
        [MinLength(ValidationConstant.PlaceLocationMin)]
        public string Location { get; set; } = string.Empty;
        [Required]
        [MaxLength(ValidationConstant.PlaceDescriptionMax)]
        [MinLength(ValidationConstant.PlaceDescriptionMin)]
        public string Description { get; set; } = string.Empty;
        public Guid TypeFishingId { get; set; }
        public virtual IEnumerable<FishingTypeViewModel>? FishingTypes { get; set; }
    }
}
