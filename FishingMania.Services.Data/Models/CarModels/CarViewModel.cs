﻿
using FishingMania.Common;
using FishingMania.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FishingMania.Services.Data.Models.CarModels
{
    public class CarViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(ValidationConstant.CarModelMax)]
        public string Model { get; set; } = string.Empty;
        public string PictureURL { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public double Price { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int AvelableCars { get; set; }
        public Guid FishingPlaceId { get; set; }
        
    }
}
