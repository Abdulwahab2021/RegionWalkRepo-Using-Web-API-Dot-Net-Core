using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;

namespace NZWalk.API.Repositories
{
    public interface IRegionRepository
    {

        Task<List<Region>> GetAllAsync();

        Task<Region?> GetById(Guid id);

        Task<Region> CreateAsync(Region region);

        Task<Region?> UpdateAsync(Guid id,  Region region);

        Task<Region?> DeleteRegion(Guid id);




    }
}
