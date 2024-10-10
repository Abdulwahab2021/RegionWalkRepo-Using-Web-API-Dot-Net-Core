using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repositories
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public Task<Region> CreateAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> DeleteRegion(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>() {

               new Region()
               {

                    Id=Guid.NewGuid(),
                    Code="SAM",
                    RegionName="Sammeer Region Name"
               }


           };
        }

        public Task<Region> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> UpdateAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
