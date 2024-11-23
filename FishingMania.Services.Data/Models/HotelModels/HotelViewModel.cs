using static FishingMania.Common.ValidationConstant;
using System.ComponentModel.DataAnnotations;

namespace FishingMania.Models.HotelModels
{
    public class HotelViewModel
    {
        public Guid Id { get; set; } = new Guid();
        [Required]
        [MaxLength(HotelNameMax)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(HotelDescriptionMax)]
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int FreePlace { get; set; }
    }
}
