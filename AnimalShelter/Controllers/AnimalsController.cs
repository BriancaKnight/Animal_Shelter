using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller 
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Animal> model = _db.Animals
                              .Include(animal => animal.Client)
                              .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

  [HttpPost]
  public ActionResult Create(Animal animal)
  {
    animal.AdmittanceDate = DateTime.Now;
    _db.Animals.Add(animal);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Details(int id)
  {
    Animal selectedAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
    return View(selectedAnimal);
  }

  public ActionResult Edit(int id)
  {
    var selectedAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
    return View(selectedAnimal);
  }

  [HttpPost]
  public ActionResult Edit(Animal animal)
  {
    _db.Animals.Update(animal);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Delete(int id)
  {
    Animal selectedAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
    return View(selectedAnimal);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Animal selectedAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
    _db.Animals.Remove(selectedAnimal);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
  }
}