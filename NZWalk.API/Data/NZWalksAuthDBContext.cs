using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalk.API.Data
{
    public class NZWalksAuthDBContext:IdentityDbContext
    {
        public NZWalksAuthDBContext(DbContextOptions<NZWalksAuthDBContext> options):base(options) 
        {
           
    }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var ReaderRoleId = "eb549929-89f6-42a3-b50a-c8ad02074246";
            var WriterRoleId = "f921c816-2f1b-41f1-a94e-991c846b5d90";
            var roles = new List<IdentityRole>
           {
               new IdentityRole  {
                   Id=ReaderRoleId,
                   ConcurrencyStamp=ReaderRoleId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper()
               },
               new IdentityRole
               {
                   Id=WriterRoleId,
                   ConcurrencyStamp=WriterRoleId,
                   Name="Writer",
                   NormalizedName="Writer".ToUpper()
               }
           };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
