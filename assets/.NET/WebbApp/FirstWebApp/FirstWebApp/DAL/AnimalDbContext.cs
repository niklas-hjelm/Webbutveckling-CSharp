using FirstWebApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApp.DAL;

public class AnimalDbContext : DbContext
{
    public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options)
    {
        
    }

    public DbSet<Animal> Animals { get; set; }
}
