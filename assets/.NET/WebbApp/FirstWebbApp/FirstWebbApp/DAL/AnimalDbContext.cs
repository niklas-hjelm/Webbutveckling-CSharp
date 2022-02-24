using FirstWebbApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebbApp.DAL;
public class AnimalDbContext : DbContext
{

    //TODO: Låter oss skicka in options när vi lägger till AnimalDbContext med Dependency Injection
    public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options)
    {

    }
    public DbSet<Animal> Animals { get; set; }
}

