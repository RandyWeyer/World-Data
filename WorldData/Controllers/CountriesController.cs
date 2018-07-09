using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorldData.Models;

namespace WorldData.Controllers
{
  public class CountriesController : Controller
  {
    [HttpGet("/countries")]
    public ActionResult Index()
    {
        List<Country> allCountries = Country.GetAll();
        return View(allCountries);
    }

    [HttpGet("/countries/new")]
    public ActionResult CreateForm()
    {
        return View();
    }

    // [HttpPost("/countries")]
    // public ActionResult Create()
    // {
    //     // Country newCountry = new Country(Request.Form["new-country"]);
    //     List<Country> allCountries = Country.GetAll();
    //     return View("Index", allCountries);
    // }
    // [HttpGet("/countries/{id}")]
    // public ActionResult Details(int id)
    // {
    //     // Country country = Country.Find(id);
    //     return View();
    // }
  }
}
