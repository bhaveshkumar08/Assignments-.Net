using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlightProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Controllers;

public class AdminController : Controller
{
    // Dependency injection
    public static Ace52024Context db;
    private readonly ISession session;
    public AdminController(Ace52024Context _db, IHttpContextAccessor httpContextAccessor)
    {
        db = _db;
        session = httpContextAccessor.HttpContext.Session;
    }

   
    public IActionResult GetAllCustomers()
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }
        
        return View(db.BCustomers.ToList());
    }

    public IActionResult GetAllFlights()
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }
        
        return View(db.BFlights.ToList());
    }

    public IActionResult GetAllBookings()
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }
        
        return View(db.BBookingDetails.ToList());
    }

    public IActionResult AddNewFlights()
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }
        
        return View();
    }

    [HttpPost]
    public IActionResult AddNewFlights(BFlight newFlight)
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }
        var newLoc = db.BLocations.Where(x => x.Locations == newFlight.Origin).SingleOrDefault();
        if(newLoc == null){
            BLocation n = new BLocation();
            n.Locations = newFlight.Origin;
            db.BLocations.Add(n);
        }
        newLoc = db.BLocations.Where(x => x.Locations == newFlight.Destination).SingleOrDefault();
        if(newLoc == null){
            BLocation n = new BLocation();
            n.Locations = newFlight.Destination;
            db.BLocations.Add(n);
        }

        db.BFlights.Add(newFlight);
        db.SaveChanges();
        return RedirectToAction("GetAllFlights");
    }

    public IActionResult EditFlight(int id)
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }

        var FlightToEdit = db.BFlights.Where(x=> x.FlightId == id).SingleOrDefault();
        
        return View(FlightToEdit);
    }

    [HttpPost]
    public IActionResult EditFlight(BFlight newFlight)
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }
        db.BFlights.Update(newFlight);
        db.SaveChanges();
        return RedirectToAction("GetAllFlights");
    }

    // Delete Flight:
    public IActionResult DeleteFlight(int id){
        BFlight delFlight = db.BFlights.Where(x=>x.FlightId == id).SingleOrDefault();
        return View(delFlight);
    }
    [HttpPost]
    [ActionName("DeleteFlight")]
    public IActionResult DeleteFlightConfirm(int id)
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }

        var FlightToDelete = db.BFlights.Where(x=> x.FlightId == id).SingleOrDefault();

        var BookingCanceled = db.BBookingDetails.Where(x=>x.FlightId == id).ToList();

        foreach (var item in BookingCanceled)
        {
            db.BBookingDetails.Remove(item);
        }
        db.BFlights.Remove(FlightToDelete);
        db.SaveChanges();
        return RedirectToAction("GetAllFlights");
    }

    public IActionResult CancelBooking(int id)
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }
        var cancelB= db.BBookingDetails.Where(x=> x.BookingId == id).SingleOrDefault();
        var changeFlight = db.BFlights.Where(b => b.FlightId == cancelB.FlightId).Select(b=>b).SingleOrDefault();
        changeFlight.SeatAvailable += cancelB.BookedSeats;
        db.BFlights.Update(changeFlight);
        db.BBookingDetails.Remove(cancelB);
        db.SaveChanges();
        return RedirectToAction("GetAllBookings");
    }


    public IActionResult LogIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult LogIn(Badmin admin)
    {
              
        Badmin conf = db.Badmins.Where(x=> x.Password == admin.Password).FirstOrDefault();
        if(conf != null){
            HttpContext.Session.SetString("Adminname", conf.AdminName);
        }
        else{
            return RedirectToAction("LogIn");
        }
        
        return RedirectToAction("GetAllFlights");
    }

    public IActionResult LogOut(){
        HttpContext.Session.Clear();
        return RedirectToAction("LogIn");
    }
    
}