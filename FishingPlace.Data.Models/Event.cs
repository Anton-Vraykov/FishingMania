using FishingMania.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingMania.Data.Models
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(ValidationConstant.EventNameMax)]
        public string Name { get; set; } = string.Empty;
        public int FreePlace { get; set; }
        [Required]
        [MaxLength(ValidationConstant.EventLocationMax)]
        public string Location { get; set; } = string.Empty;
        [Required]
        [MaxLength(ValidationConstant.EventDescriptionMax)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string ImageURL { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public double Price { get; set; }
        public Guid FishingPlaceId { get; set; }
        [ForeignKey(nameof(FishingPlaceId))]
        public FishingPlace FishingPlace { get; set; } = null!;
        public bool IsDeleted { get; set; }

    }
}
