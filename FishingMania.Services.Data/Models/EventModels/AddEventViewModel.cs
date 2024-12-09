

using FishingMania.Common;
using System.ComponentModel.DataAnnotations;

namespace FishingMania.Services.Data.Models.EventModels
{
    public class AddEventViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(ValidationConstant.EventNameMax)]
        [MinLength(ValidationConstant.EventNameMin)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0, 1000)]
        public int FreePlace { get; set; }
        [Required]
        [MaxLength(ValidationConstant.EventDescriptionMax)]
        [MinLength(ValidationConstant.EventDescriptionMin)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(ValidationConstant.EventLocationMax)]
        [MinLength(ValidationConstant.EventLocationMin)]
        public string Location { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        [Required]
        public string ImageURL { get; set; } = string.Empty;
        [Required]
        [Range(0,100000)]
        public double Price { get; set; }
        public Guid FishingPlaceId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
