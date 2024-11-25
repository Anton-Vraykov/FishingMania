

using FishingMania.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static FishingMania.Common.ValidationConstant;

namespace FishingMania.Services.Data.Models.HotelModels
{
    public class HotelDetailViewModel
    {
        public Guid Id { get; set; } = new Guid();
        [Required]
        [MaxLength(HotelNameMax)]
        public string Name { get; set; } = string.Empty;
        public string PictureURL { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(HotelDescriptionMax)]
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int FreePlace { get; set; }
        public int MyProperty { get; set; }
        public Guid FishingPlaceId { get; set; }

    }
}
