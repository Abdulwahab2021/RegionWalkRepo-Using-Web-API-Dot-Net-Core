﻿using System.ComponentModel.DataAnnotations;

namespace NZWalk.API.Models.DTO
{
    public class UpdateWalkRequestDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [Range(0, 50)]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid RegionId { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
    }
}
