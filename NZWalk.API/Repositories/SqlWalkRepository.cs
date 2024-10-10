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
    }
}
