#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FirstWebbApp.DAL;
using FirstWebbApp.DAL.Models;

namespace FirstWebbApp.Pages.Animals
{
    public class DetailsModel : PageModel
    {
        private readonly FirstWebbApp.DAL.AnimalDbContext _context;

        public DetailsModel(FirstWebbApp.DAL.AnimalDbContext context)
        {
            _context = context;
        }

        public Animal Animal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Animal = await _context.Animals.FirstOrDefaultAsync(m => m.Id == id);

            if (Animal == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
