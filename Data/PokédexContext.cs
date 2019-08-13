using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pokédex.Models
{
    public class PokédexContext : DbContext
    {
        public PokédexContext (DbContextOptions<PokédexContext> options)
            : base(options)
        {
        }

        public DbSet<Pokédex.Models.Pokémon> Pokémon { get; set; }
    }
}
