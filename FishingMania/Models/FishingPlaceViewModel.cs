using FishingMania.Common;
using System.ComponentModel.DataAnnotations;

namespace FishingMania.Models
{
    public class FishingPlaceViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(ValidationConstant.PlaceNameMax)]
        [MinLength(ValidationConstant.PlaceNameMin)]
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
        public string UserId { get; set; } = string.Empty;
        public Guid TypeFishingId { get; set; }
        

    }
}
