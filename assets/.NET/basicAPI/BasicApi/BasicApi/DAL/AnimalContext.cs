using BasicApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicApi.DAL
{
    public class AnimalContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-94UMSFPO;Initial Catalog=Databases Database=AnimalDb;Integrated Security=True;Pooling=False");
        }
    }
}
