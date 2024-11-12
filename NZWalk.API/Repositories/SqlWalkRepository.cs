using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;
using System.Globalization;

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
            await _dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAsync(string? filterOn=null, string? filterQuery=null, string ? Sortby=null,bool IsAscending=true,
             int PagerNumber = 1, [FromQuery] int Pagesize = 1000)
        {
            var walk =   _dbContext.walks
                .Include(w => w.Region)
                .Include(w => w.Difficulty)
                .AsQueryable();
            //filtering
            if(!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walk = walk.Where(x => x.Name.Contains(filterQuery));
                }
            }
            //Sorting 

            if(string.IsNullOrEmpty(Sortby)==false)
            {
                if (Sortby.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walk = IsAscending ? walk.OrderBy(x => x.Name) : walk.OrderByDescending(x => x.Name);
                }
            }

            //Pagination
            var skipResult = (PagerNumber - 1) * Pagesize;


            return await walk.Skip(skipResult).Take(Pagesize).ToListAsync();

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
                ExistingDomain.WalkImageUrl = walk.WalkImageUrl;
                ExistingDomain.LengthInKm = walk.LengthInKm;
                ExistingDomain.Description = walk.Description;

                await _dbContext.SaveChangesAsync();
                return ExistingDomain;
            }




        }

    }
}
