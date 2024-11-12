using System.ComponentModel.DataAnnotations;

namespace NZWalk.API.Models.Domain
{
    public class AddRegionRequestDto
    {

        [Required]
        [MinLength(3, ErrorMessage = "Code has to be a minimum of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be a Maximum of 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Region Name has to be a maximum of 100 characters")]
        public string RegionName { get; set; }

        public string? RegionImageUrl { get; set; }


    }
}
