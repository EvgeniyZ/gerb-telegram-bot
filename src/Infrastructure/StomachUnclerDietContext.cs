using Gerb.Telegram.Bot.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Gerb.Telegram.Bot.Infrastructure
{
    public class StomachUnclerDietContext : DbContext
    {
        public StomachUnclerDietContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Recommendation> Recomendations { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<Section> Sections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().ToTable("food")
                .HasKey(x => x.Id);
            modelBuilder.Entity<Recommendation>().ToTable("recommendation")
                .HasKey(x => x.Id);
            modelBuilder.Entity<Restriction>().ToTable("restriction")
                .HasKey(x => x.Id);
            modelBuilder.Entity<Section>().ToTable("section")
                .HasKey(x => x.Id);
        }
    }
}