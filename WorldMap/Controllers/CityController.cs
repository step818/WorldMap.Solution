using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldMap.Models;

namespace WorldMap.Controllers
{
  public class CityController : Controller
  {

    [Route("/city")]
    public ActionResult Index() 
    {
      List<City> allCities = City.GetAll();
      return View(allCities);
    }
  }
}
