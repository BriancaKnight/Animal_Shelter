using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Controllers
{
  public class ClientsController: Controller
  {
    private readonly AnimalShelterContext _db;

    public ClientsController(AnimalShelterContext db)
    { 
      _db = db;
    }

    public ActionResult Index()
    {
      List<Client> model = _db.Clients.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
      _db.Clients.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Client selectedClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      return View(selectedClient);
    }
    
    public ActionResult Edit (int id)
    {
      Client selectedClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      return View(selectedClient);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
      _db.Clients.Update(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Client selectedClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      return View(selectedClient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Client selectedClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      _db.Clients.Remove(selectedClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}