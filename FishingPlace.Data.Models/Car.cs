using FishingMania.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingMania.Data.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(ValidationConstant.CarModelMax)]
        public string Model { get; set; } = string.Empty;
        public string PictureURL { get; set; } = string.Empty;
        public double Price { get; set; }
        [MaxLength(ValidationConstant.CarDescriptionMax)]
        public string Details { get; set; }= string.Empty;
        [MaxLength(ValidationConstant.CarLocationMax)]
        public string Location { get; set; }=string.Empty;
        public int AvelableCars { get; set; }
        public string UserId { get; set; } = string.Empty;
        public Guid FishingPlaceId { get; set; }
        [ForeignKey(nameof(FishingPlaceId))]
        public FishingPlace FishingPlace { get; set; } = null!;
        public bool IsDeleted { get; set; }

    }
}
