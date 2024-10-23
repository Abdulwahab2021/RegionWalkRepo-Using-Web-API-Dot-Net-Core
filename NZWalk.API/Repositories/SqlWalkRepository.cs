using Microsoft.EntityFrameworkCore;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repositories
{
    public class SqlWalkRepository : IWalkRepository
    {
        private readonly NZWalkDbContext _dbContext;

        public SqlWalkRepository(NZWalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
           await _dbContext.walks.AddAsync(walk);
          await  _dbContext.SaveChangesAsync();

            return walk;
        }

          public async Task<List<Walk>> GetAllAsync()
          {
           var result =  await _dbContext.walks
                         .Include(w=>w.Region)
                         .Include(w=>w.Difficulty)
                  .ToListAsync();
              return result;
          }

           public async Task<Walk?> GetWalkById(Guid id)
           {
              var walk = await _dbContext.walks.Include("Region").Include("Difficulty").Where(s => s.Id == id).FirstOrDefaultAsync();
              return walk;
           }

          public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
          {
              var ExistingDomain = await _dbContext.walks.Where(s => s.Id == id).FirstOrDefaultAsync();
              if (ExistingDomain == null)
              {
                  return null;
              }
              else
              {
                  ExistingDomain.Name = walk.Name;
                  ExistingDomain.DifficultyId = walk.DifficultyId;
                  ExistingDomain.RegionId = walk.RegionId;
                  ExistingDomain.WalkImageUrl= walk.WalkImageUrl;
                  ExistingDomain.LengthInKm = walk.LengthInKm;
                  ExistingDomain.Description= walk.Description;

                 await _dbContext.SaveChangesAsync();
                  return ExistingDomain;
              }

          }
    }
}
