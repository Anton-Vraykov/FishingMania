using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
      
        public Guid FishingPlaceId { get; set; }
        [ForeignKey(nameof(FishingPlaceId))]
        public FishingPlace FishingPlace { get; set; } = null!;
        


    }
}
