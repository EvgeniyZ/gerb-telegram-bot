using Gerb.Telegram.Bot.Domain.Entities;
using Gerb.Telegram.Bot.Extensions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Gerb.Telegram.Bot.Infrastructure
{
    public class DietContext : DbContext
    {
        public DietContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Recommendation> Recomendations { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<Section> Sections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UseSnakeCase(modelBuilder);
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
            });
        }

        private static void UseSnakeCase(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                // Replace table names
                entity.Relational().TableName = entity.Relational().TableName.ToSnakeCase();

                // Replace column names
                foreach (var property in entity.GetProperties())
                {
                    property.Relational().ColumnName = property.Name.ToSnakeCase();
                }

                foreach (var key in entity.GetKeys())
                {
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.Relational().Name = index.Relational().Name.ToSnakeCase();
                }
            }
        }
    }
}