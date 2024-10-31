using FishingMania.Common;
using System.ComponentModel.DataAnnotations;

namespace FishingMania.Data.Models
{
    public class TypesFishing
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(ValidationConstant.TypeNameMax)]
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<FishingPlace> FishingPlaces { get; set; } = new List<FishingPlace>();
    }
}
