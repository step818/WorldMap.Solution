using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldMap.Models;

namespace WorldMap.Controllers
{
  public class CityController : Controller
  {

    [Route("/cities")]
    public ActionResult Index() 
    {
      List<City> allCities = City.GetAll();
      return View(allCities);
    }
  }
}
