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
    public class DetailsModel : PageModel
    {
        private readonly Pokédex.Models.PokédexContext _context;

        public DetailsModel(Pokédex.Models.PokédexContext context)
        {
            _context = context;
        }

        public Pokémon Pokémon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pokémon = await _context.Pokémon.FirstOrDefaultAsync(m => m.ID == id);

            if (Pokémon == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
