﻿using static FishingMania.Common.ValidationConstant;
using System.ComponentModel.DataAnnotations;

namespace FishingMania.Services.Data.Models.HotelModels
{
    public class AddHotelViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(HotelNameMax)]
        public string Name { get; set; } = string.Empty;
        public string PictureURL { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        [Required]
        [MaxLength(HotelDescriptionMax)]
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int FreePlace { get; set; }
    }
}
