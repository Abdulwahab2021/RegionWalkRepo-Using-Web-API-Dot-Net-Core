using Microsoft.EntityFrameworkCore;
using NZWalk.API.Models.Domain;

namespace NZWalk.API.Data
{
    public class NZWalkDbContext : DbContext
    {
        public NZWalkDbContext(DbContextOptions<NZWalkDbContext> dbContext) : base(dbContext) { }


        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {

                new Difficulty()
                {

                 Id=Guid.Parse("0e2f202e-0af6-4c91-9139-9153b950bbfa"),
                 Name="Easy"
                },

                 new Difficulty()
                {

                 Id=Guid.Parse("0eedf313-3fbe-44b3-ab3a-74a4702436fd"),
                 Name="Medium"
                },

                 new Difficulty()
                {

                 Id=Guid.Parse("17403890-c4f4-4cd4-81a9-f552524f2ae7"),
                 Name="Hard"
                },

            };


            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var Regions = new List<Region>()
            {

                new Region()
                {
                     Id=Guid.Parse("647164aa-27d7-4c84-81fc-be52753c24d8"),
                  RegionName="Auckland",
                   RegionImageUrl="https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1\"\n                },",
                    Code="AKL"
                },
                    new Region()
                {
                     Id=Guid.Parse("95cb4e28-78cb-4e71-b50f-df4fb635e55a"),
                  RegionName="NorthLan",
                    Code="NTL",
                     RegionImageUrl=""
                },

                   new Region()
                {
                     Id=Guid.Parse("d90f7a7b-dc1a-44e3-a5fe-ae22929aadf5"),
                  RegionName="Bay of Plenty",
                    Code="AKL",
                   RegionImageUrl="",
                },

                 new Region()
                {
                     Id=Guid.Parse("94f069ad-79fe-4f89-bb95-322ab9d93dba"),
                  RegionName="Nelson",
                    Code="NSN",
                   RegionImageUrl="",
                },
                new Region()
                {
                     Id=Guid.Parse("4f4bcee7-d3bd-48bb-961b-7c7836bf8b96"),
                  RegionName="SouthLand",
                    Code="STL",
                   RegionImageUrl="",
                },
                 new Region
                {
                    Id = Guid.Parse("54571568-6cf0-4e40-a638-e4457f61bcfa"),
                    RegionName = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                }
            };
            modelBuilder.Entity<Region>().HasData(Regions);
        }
    }
}
