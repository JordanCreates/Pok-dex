using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokédex.Models
{
    public class Pokémon
    {
        public int ID { get; set; }

        public int DexNumber { get; set; }

        public string Name { get; set; }

        public string Type1 { get; set; }

        public string Type2 { get; set; }

        public string RedBlue { get; set; }

    }
}
