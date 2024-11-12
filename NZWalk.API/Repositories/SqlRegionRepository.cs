using Microsoft.EntityFrameworkCore;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repositories
{
    public class SqlRegionRepository : IRegionRepository
    {

        private readonly NZWalkDbContext _dbContext;
        public SqlRegionRepository(NZWalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
           var result = await _dbContext.Regions.ToListAsync();
            return result;
        }

        public async Task<Region?> GetById(Guid id)
        {
            var regionDomainModel = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            return regionDomainModel;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
          var existingRegion=  await _dbContext.Regions.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (existingRegion==null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.RegionName = region.RegionName;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

          await  _dbContext.SaveChangesAsync();

            return existingRegion;

        }

        public async Task<Region?> DeleteRegion(Guid id)
        {
          var existingRegion =await  _dbContext.Regions.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingRegion == null)
            {
                return null;
            }

            _dbContext.Regions.Remove(existingRegion);
            await _dbContext.SaveChangesAsync();
            return existingRegion;

        }


    }
}
