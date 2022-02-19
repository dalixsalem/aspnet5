using Microsoft.EntityFrameworkCore;

namespace fristapp.data
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)

        {
        builder.Entity<country>().HasData(
      new country(){ Id=1, Name = "france", ShortName = "fr" },
      new country() { Id = 2, Name = "alegriya", ShortName = "al0" },
      new country() { Id = 3, Name = "italiya", ShortName = "it" }
     );
            builder.Entity<hotel>().HasData(
                new hotel() {Id = 4, Name = "yallapalce",
                    Adress = "benzert",Rating = 2,
                    countryid = 1}
                );
        }
        public DbSet<country> Countries { get; set; }
        public DbSet<hotel> hotels { get; set; }
    }
}
