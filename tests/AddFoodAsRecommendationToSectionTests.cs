using System;
using System.Linq;
using System.Threading.Tasks;
using Gerb.Telegram.Bot.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Gerb.Telegram.Bot.Domain.Entities;

namespace Gerb.Unit.Tests
{
    public class AddFoodAsRecommendationToSectionTests : IDisposable
    {
        private readonly DbContextOptions<DietContext> _options;

        public AddFoodAsRecommendationToSectionTests()
        {
            _options = new DbContextOptionsBuilder<DietContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
        }

        [Fact]
        public async Task AddFoodAsRecommendation()
        {
            var sectionName = "Рыба";
            var foodName = "Минтай";
            using (var context = new DietContext(_options))
            {
                var section = await context.Sections.FirstOrDefaultAsync(x => x.Name == sectionName);
                if (section is null) 
                {
                    return;
                }
                await context.Recomendations.AddAsync(new Recommendation
                {
                    Food = new Food
                    {
                        Name = foodName
                    },
                    Section = section
                });
                await context.SaveChangesAsync();
                Assert.True(section.Recommendations.Any(x => x.Food.Name == foodName));
            }
        }

        public void Dispose()
        {
            using (var context = new DietContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}