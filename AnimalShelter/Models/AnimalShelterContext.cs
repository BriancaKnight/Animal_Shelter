using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext: DbContext
  {
    public AnimalShelterContext(DbContextOptions options) : base(options) { }
  }
}