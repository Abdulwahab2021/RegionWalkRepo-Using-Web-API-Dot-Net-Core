namespace NZWalk.API.Models.DTO
{
    public class RegionShowDTO
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string RegionName { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
