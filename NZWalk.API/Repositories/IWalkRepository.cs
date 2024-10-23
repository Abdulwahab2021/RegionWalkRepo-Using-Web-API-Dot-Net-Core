using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repositories
{
    public interface IWalkRepository
    {
         Task<Walk> CreateAsync(Walk walk);
         Task<List<Walk>> GetAllAsync();

         Task<Walk?> GetWalkById(Guid id);

         Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);

    }
}
