using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pokédex.Models;

namespace Pokédex.Pages.Kanto
{
    public class CreateModel : PageModel
    {
        private readonly Pokédex.Models.PokédexContext _context;

        public CreateModel(Pokédex.Models.PokédexContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pokémon Pokémon { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pokémon.Add(Pokémon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}