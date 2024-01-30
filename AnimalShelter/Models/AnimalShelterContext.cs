using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext: DbContext
  {
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Client> Clients { get; set; }
    public AnimalShelterContext(DbContextOptions options) : base(options) { }
  }
}