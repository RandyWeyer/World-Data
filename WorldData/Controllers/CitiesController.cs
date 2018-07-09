using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorldData.Models;

namespace WorldData.Controllers
{
  public class CitiesController : Controller
  {
    [HttpGet("/cities")]
    public ActionResult Index()
    {
        List<City> allCities = City.GetAll();
        return View(allCities);
    }

    [HttpGet("/countries/new")]
    public ActionResult CreateForm()
    {
        return View();
    }

    // [HttpPost("/countries")]
    // public ActionResult Create()
    // {
    //     // City newCity = new City(Request.Form["new-country"]);
    //     List<City> allCities = City.GetAll();
    //     return View("Index", allCities);
    // }
    // [HttpGet("/countries/{id}")]
    // public ActionResult Details(int id)
    // {
    //     // City country = City.Find(id);
    //     return View();
    // }
  }
}
