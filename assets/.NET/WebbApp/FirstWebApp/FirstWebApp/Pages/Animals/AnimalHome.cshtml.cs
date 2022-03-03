#nullable disable
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FirstWebApp.DAL;
using FirstWebApp.DAL.Models;
using NuGet.Packaging;

namespace FirstWebApp.Pages.Animals
{
    public class AnimalHomeModel : PageModel
    {
        private readonly AnimalDbContext _context;

        public AnimalHomeModel(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            Animals.AddRange(_context.Animals.Where(_=>true).ToList());

            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; }

        [BindProperty] public ObservableCollection<Animal> Animals { get; set; } = new();

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
