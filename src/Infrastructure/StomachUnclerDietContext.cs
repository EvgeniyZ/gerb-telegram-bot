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
            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("food");
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();
            });
            modelBuilder.Entity<Recommendation>(entity =>
            {
                entity.ToTable("recommendation");
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Food);
                entity.HasOne(x => x.Section);
            });
            modelBuilder.Entity<Restriction>(entity =>
            {
                entity.ToTable("restriction");
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Food);
                entity.HasOne(x => x.Section);
            });
            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("section");
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();
                entity.HasMany(x => x.Recomendations);
                entity.HasMany(x => x.Restrictions);
            });
        }
    }
}