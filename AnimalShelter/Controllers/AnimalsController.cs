using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    private async Task<List<Animal>> SearchMethod(string query)
    {
      IQueryable<Animal> results = _db.Set<Animal>().Include(animal => animal.Client);

      if (query != null)
      {
        return await results?.Where(animal => animal.AnimalName.Contains(query)).ToListAsync();
      }
      else 
      {
        return await results.ToListAsync();
      }
    }

    public async Task<IActionResult> Index(string query)
    {
      List<Animal> resultList = await SearchMethod(query);
      return View(resultList);
    }

    // public ActionResult Index()
    // {
    //   List<Animal> model = _db.Animals
    //                           .Include(animal => animal.Client)
    //                           .ToList();
    //   ViewBag.PageTitle = "View All Animals";
    //   return View(model);
    // }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add a New Animal";
      ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "ClientName");
      // ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }

  [HttpPost]
  public ActionResult Create(Animal animal)
  {
    if (animal.ClientId == 0)
    {
      return RedirectToAction("Create");
    }
    ViewBag.PageTitle = "Can you see this???";
    animal.AdmittanceDate = DateTime.Now;
    _db.Animals.Add(animal);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Details(int id)
  {
    Animal selectedAnimal = _db.Animals
                                  .Include(animal => animal.Client)
                                  .FirstOrDefault(animal => animal.AnimalId == id);
    ViewBag.PageTitle = $"Details - {selectedAnimal.AnimalName}";
    return View(selectedAnimal);
  }

  public ActionResult Edit(int id)
  {
    var selectedAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
    ViewBag.PageTitle = $"Edit - {selectedAnimal.AnimalName}";
    ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "ClientName");
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
    ViewBag.PageTitle = $"Delete - {selectedAnimal.AnimalName}";
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