

using FishingMania.Common;
using System.ComponentModel.DataAnnotations;

namespace FishingMania.Services.Data.Models.CarModels
{
    public class CarDetailViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(ValidationConstant.CarModelMax)]
        public string Model { get; set; } = string.Empty;
        public string PictureURL { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Details { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int AvelableCars { get; set; }
        public string UserId { get; set; } = string.Empty;
        public Guid FishingPlaceId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
