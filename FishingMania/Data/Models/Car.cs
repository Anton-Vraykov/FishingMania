using FishingMania.Common;
using System.ComponentModel.DataAnnotations;

namespace FishingMania.Data.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(ValidationConstant.CarModelMax)]
        public string Model { get; set; } = string.Empty;
        public DateTime? Rezervation { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<FishingPlace> FishingPlaces { get; set; } = new HashSet<FishingPlace>();
    }
}
