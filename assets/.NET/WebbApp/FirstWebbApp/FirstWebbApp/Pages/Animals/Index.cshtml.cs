#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FirstWebbApp.DAL;
using FirstWebbApp.DAL.Models;

namespace FirstWebbApp.Pages.Animals;
public class IndexModel : PageModel
{
    private readonly AnimalDbContext _context;

    public IndexModel(AnimalDbContext context)
    {
        _context = context;
    }

    public IList<Animal> Animal { get; set; }

    public async Task OnGetAsync()
    {
        Animal = await _context.Animals.ToListAsync();
    }
}

