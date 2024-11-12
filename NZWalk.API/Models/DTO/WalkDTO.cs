using NZWalk.API.Models.Domain;

namespace NZWalk.API.Models.DTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? WalkImageUrl { get; set; }

        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }

        // Navigation Properties
        public Region Region { get; set; }
        public Difficulty Difficulty { get; set; }


    }
}
