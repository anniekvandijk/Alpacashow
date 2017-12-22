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
        public DbSet<HaltershowEvent> HaltershowEvents { get; set; }
        public DbSet<FleeceshowEvent> FleeceshowEvents { get; set; }
        public DbSet<HaltershowAnimal> HaltershowAnimals { get; set; }
        public DbSet<FleeceshowAnimal> FleeceshowAnimals { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<AgeClass> AgeClasses { get; set; }
        public DbSet<MaleProgeny> MaleProgeny { get; set; }
        public DbSet<FemaleProgeny> FemaleProgeny { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
