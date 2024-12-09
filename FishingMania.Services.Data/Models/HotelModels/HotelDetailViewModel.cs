

using FishingMania.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static FishingMania.Common.ValidationConstant;

namespace FishingMania.Services.Data.Models.HotelModels
{
    public class HotelDetailViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(HotelNameMax)]
        [MinLength(HotelNameMIn)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string PictureURL { get; set; } = string.Empty;
        [Required]
        [MaxLength(HotelLocationMax)]
        [MinLength(HotelLocationMin)]
        public string Location { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(HotelDescriptionMax)]
        [MinLength(HotelDescriptionMIn)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Range(0, 100000)]
        public double Price { get; set; }
        [Required]
        [Range(0, 1000)]
        public int FreePlace { get; set; }
        public Guid FishingPlaceId { get; set; }
    }
}
