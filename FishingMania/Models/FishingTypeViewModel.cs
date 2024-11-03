using System.ComponentModel.DataAnnotations;

namespace FishingMania.Models
{
    public class FishingTypeViewModel
    {
        public Guid Id { get; set; }       
        public string Name { get; set; } = string.Empty;
    }
}
