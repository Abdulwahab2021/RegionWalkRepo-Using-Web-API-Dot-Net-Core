﻿namespace NZWalk.API.Models.Domain
{
    public class Walk
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid RegionId { get; set; }

        public Guid DifficultiyId { get; set; }

        // Navigation Property
        public Region Region { get; set; }
        public Difficulty Difficulty { get; set; }





    }
}