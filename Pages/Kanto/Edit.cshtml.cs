using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokédex.Models;

namespace Pokédex.Pages.Kanto
{
    public class EditModel : PageModel
    {
        private readonly Pokédex.Models.PokédexContext _context;

        public EditModel(Pokédex.Models.PokédexContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pokémon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokémonExists(Pokémon.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PokémonExists(int id)
        {
            return _context.Pokémon.Any(e => e.ID == id);
        }
    }
}
