using System;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Type { get; set; }
    public DateTime AdmittanceDate { get; set; }
    public string AnimalName { get; set; }
    public string AnimalBreed { get; set; }
  }
}