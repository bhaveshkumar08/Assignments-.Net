using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlightProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlightProject.Controllers;

public class SearchFlightsController : Controller
{
    // Dependency injection
    public static Ace52024Context? db;
    public SearchFlightsController(Ace52024Context _db){
        db = _db;
    }

    public IActionResult SearchFlights(){
        ViewBag.Origins = new SelectList(db.BLocations, "Locations", "Locations");
        return View();
    }

    [HttpPost]
    public IActionResult SearchResults(SearchCapture srchCap){
        ViewBag.Seats = srchCap.seats;
        List<BFlight> temp = new List<BFlight>();
        foreach (var item in db.BFlights)
        {
            if(item.Origin == srchCap.origin && item.Destination == srchCap.destination && item.Departure == srchCap.departure){
                temp.Add(item);
            }
        }

        if(temp.Count == 0){
            ViewBag.count = 0;
        }
           
        return View(temp);
    }
}
