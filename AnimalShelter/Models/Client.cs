using System.Collections.Generic;

namespace AnimalShelter.Models
{
  public class Client
  {
    public int ClientId { get; set; }
    public string ClientName { get; set; }
    public List<Animal> Animals { get; set; }
  }
}