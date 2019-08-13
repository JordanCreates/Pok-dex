using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pokédex.Models;

namespace Pokédex.Pages.Kanto
{
    public class IndexModel : PageModel
    {
        private readonly Pokédex.Models.PokédexContext _context;

        public IndexModel(Pokédex.Models.PokédexContext context)
        {
            _context = context;
        }

        public IList<Pokémon> Pokémon { get;set; }

        public async Task OnGetAsync()
        {
            Pokémon = await _context.Pokémon.ToListAsync();
        }
    }
}
