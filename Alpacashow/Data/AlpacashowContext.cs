using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Alpacashow.Models;
using Microsoft.EntityFrameworkCore;

namespace Alpacashow.Data
{
    public class AlpacashowContext : DbContext
    {
        public AlpacashowContext(DbContextOptions<AlpacashowContext> options) : base(options)
        {
        }
        public DbSet<ShowEvent> ShowEvents { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<AgeClass> AgeClasses { get; set; }

    }
}
