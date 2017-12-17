using Alpacashow.Data.Models;
using Alpacashow.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Alpacashow.Data.Context
{
    public class AlpacashowContext : DbContext
    {
        public AlpacashowContext(DbContextOptions<AlpacashowContext> options) : base(options)
        {
        }
        public DbSet<ShowEvent> ShowEvents { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<AgeClass> AgeClasses { get; set; }
        public DbSet<ShowType> ShowTypes { get; set; }
        public DbSet<ShowEventAnimal> ShowEventAnimals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShowEventAnimal>()
                .HasKey(t => new { t.AnimalId, t.ShowEventId });
        }
    }
}
