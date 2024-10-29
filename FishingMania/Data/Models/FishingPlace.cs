using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FishingMania.Common;
using Microsoft.AspNetCore.Identity;

namespace FishingMania.Data.Models
{
    public class FishingPlace
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(ValidationConstant.PlaceNameMax)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string PictureURL { get; set; } = string.Empty;
        [Required]
        [MaxLength(ValidationConstant.PlaceLocationMax)]
        public string Location { get; set; } = string.Empty;
        public DateTime Reservation { get; set; }
        [Required]
        [MaxLength(ValidationConstant.PlaceDescriptionMax)]
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string UserId { get; set; }=string.Empty;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Cars { get; set; } = null!;
        public Guid TypeFishingId { get; set; }
        [ForeignKey(nameof(TypeFishingId))]
        public TypesFishing TypesFishing { get; set; } = null!;
        public Guid EventId { get; set; }
        [ForeignKey(nameof(EventId))]
        public Event Events { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public virtual ICollection<ApplicationUserFishingPlace> ApplicationUserProduct { get; set; }
            = new HashSet<ApplicationUserFishingPlace>();

    }
}
