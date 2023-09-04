using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //optionsBuilder.UseMySQL("server=localhost;user id=root;password=Welcome@12345;database=klnmtr");
            //var _context = new ApplicationDbContext(optionsBuilder.Options);
        }

        public ApplicationDbContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            if(string.IsNullOrEmpty(connectionString))
            {
                connectionString = "klnmtr";
            }
            string path = "server=localhost;user id=root;password=Welcome@12345;database=" + connectionString;
            return MySQLDbContextOptionsExtensions.UseMySQL(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>()
                .HasData(
                    new Villa()
                    {
                        Id = 1,
                        Name = "Royal Villa",
                        Details = "Royal Villa Details",
                        ImageUrl = "https://v7n2u8v7.rocketcdn.me/wp-content/uploads/2018/09/229DeF2-L3-1.jpg",
                        Occupancy = 5,
                        Rate = 200,
                        Sqft = 500,
                        Amenity = "",
                        CreatedDate = DateTime.Now
                    }
                );
        }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySQL("server=localhost;user id=root;password=Welcome@12345;database=klnmtr");
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
