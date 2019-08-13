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
                // Look for any movies.
                if (context.Pokémon.Any())
                {
                    return;   // DB has been seeded
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
                        Name = "Charmander",
                        Type1 = "Fire"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}