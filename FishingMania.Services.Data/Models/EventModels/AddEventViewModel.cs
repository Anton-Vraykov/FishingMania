

using FishingMania.Common;
using System.ComponentModel.DataAnnotations;

namespace FishingMania.Services.Data.Models.EventModels
{
    public class AddEventViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(ValidationConstant.EventNameMax)]
        public string Name { get; set; } = string.Empty;
        public int FreePlace { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        [Required]
        public string ImageURL { get; set; } = string.Empty;
        public double Price { get; set; }
        public Guid FishingPlaceId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
