#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FirstWebApp.DAL;
using FirstWebApp.DAL.Models;

namespace FirstWebApp.Pages.Animals
{
    public class AnimalHomeModel : PageModel
    {
        private readonly AnimalDbContext _context;

        public AnimalHomeModel(AnimalDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var animalExists = _context.Animals.Where(a => Animal.Name == a.Name);
            if (animalExists.Any())
            {
                return Page();
            }

            _context.Animals.Add(Animal);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
