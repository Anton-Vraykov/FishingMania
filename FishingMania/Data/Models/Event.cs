using FishingMania.Common;
using System.ComponentModel.DataAnnotations;

namespace FishingMania.Data.Models
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(ValidationConstant.EventNameMax)]
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        [Required]
        public string ImageURL { get; set; } = string.Empty;
        public double Price { get; set; }
        public virtual ICollection<FishingPlace> FishingPlaces { get; set; } = new HashSet<FishingPlace>();
    }
}
