using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repositories
{
    public interface IWalkRepository
    {
     Task<Walk> CreateAsync(Walk walk);

        Task<List<Walk>> GetAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? Sortby, [FromQuery] bool IsAscending=true,
            int PagerNumber=1 ,int Pagesize=1000);
        Task<Walk?> GetWalkById(Guid id);

        Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);




    }
}
