using System.ComponentModel.DataAnnotations;
using static FishingMania.Common.ValidationConstant;

namespace FishingMania.Data.Models
{
    public class Hotel
    {
        [Key]
        public Guid Id { get; set; } = new Guid();
        [Required]
        [MaxLength(HotelNameMax)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(HotelDescriptionMax)]
        public string Description { get; set; }= string.Empty;
        public double Price { get; set; }
        public int FreePlace { get; set; }
        public virtual ICollection<FishingPlace> FishingPlaces { get; set; } = new List<FishingPlace>();


    }
}
