

using FishingMania.Common;
using System.ComponentModel.DataAnnotations;

namespace FishingMania.Services.Data.Models.CarModels
{
    public class CarDetailViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(ValidationConstant.CarModelMax)]
        [MinLength(ValidationConstant.CarModelMin)]
        public string Model { get; set; } = string.Empty;
        [Required]
        public string PictureURL { get; set; } = string.Empty;
        public double Price { get; set; }
        [Required]
        [MaxLength(ValidationConstant.CarDescriptionMax)]
        [MinLength(ValidationConstant.CarDescriptionMin)]
        public string Details { get; set; } = string.Empty;
        [Required]
        [MaxLength(ValidationConstant.CarLocationMax)]
        [MinLength(ValidationConstant.CarLocationMin)]
        public string Location { get; set; } = string.Empty;
        [Required]
        [Range(0, 1000)]
        public int AvelableCars { get; set; }
        public string UserId { get; set; } = string.Empty;
        public Guid FishingPlaceId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
