using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Pokédex.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PokédexContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PokédexContext>>()))
            {
                if (context.Pokémon.Any())
                {
                    return;
                }

                context.Pokémon.AddRange(
                    new Pokémon
                    {
                        DexNumber = 1,
                        Name = "Bulbasaur",
                        Type1 = "Grass",
                        Type2 = "Poison",
                        RedBlue = "A strange seed was planted on its back at birth. The plant sprouts and grows with this Pokémon."
                    },

                    new Pokémon
                    {
                        DexNumber = 2,
                        Name = "Ivysaur",
                        Type1 = "Grass",
                        Type2 = "Poison",
                        RedBlue = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs."
                    },

                    new Pokémon
                    {
                        DexNumber = 3,
                        Name = "Venusaur",
                        Type1 = "Grass",
                        Type2 = "Poison",
                        RedBlue = "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}