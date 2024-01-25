using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlightProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Controllers;

public class BookingController : Controller
{
    // Dependency injection
    public static Ace52024Context db;
    private readonly ISession session;
    public BookingController(Ace52024Context _db, IHttpContextAccessor httpContextAccessor)
    {
        db = _db;
        session = httpContextAccessor.HttpContext.Session;
    }

   
    public IActionResult BookingConfirm(int id, int seats)
    {
        ViewBag.username = HttpContext.Session.GetString("Username");
        if(ViewBag.username == null){
            return RedirectToAction("Login", "Login");   
        }
        FullBookingDetails newBooking = new FullBookingDetails();
        BFlight f = db.BFlights.Where(x=>x.FlightId == id).SingleOrDefault();
        newBooking.FlightId = id;
        newBooking.Arrival = f.Arrival;
        newBooking.TotalCost = seats*f.Cost;
        newBooking.BookedSeats = seats;
        newBooking.Departure = f.Departure;
        newBooking.Origin = f.Origin;
        newBooking.Destination = f.Destination;
        newBooking.FlightName = f.FlightName;
        newBooking.CustomerId = HttpContext.Session.GetInt32("UserId");
        return View(newBooking);
    }

        
    [HttpPost]
    // get and post action should have same name
    public IActionResult BookingConfirm(FullBookingDetails f)
    {
        ViewBag.usename = HttpContext.Session.GetString("Username");
        if(ViewBag.usename == null){
            return RedirectToAction("Login", "Login");   
        }
        BBookingDetail nb = new BBookingDetail();
        nb.CustomerId = f.CustomerId;
        nb.BookedSeats = f.BookedSeats;
        nb.FlightId = f.FlightId;
        nb.TotalCost = f.TotalCost;
        BFlight fchange = db.BFlights.Where(x=>x.FlightId == f.FlightId).FirstOrDefault();  
        fchange.SeatAvailable -= f.BookedSeats;
        db.BFlights.Update(fchange);

        db.BBookingDetails.Add(nb);
    
        db.SaveChanges();
        return RedirectToAction("BookingHistory");
    }
    
    public IActionResult BookingHistory()
    {
        int? id = HttpContext.Session.GetInt32("UserId");
        if(id == null){
            return RedirectToAction("Login", "Login");   
        }
        List<FullBookingDetails> newBooking = new List<FullBookingDetails>();
        var allbooking = db.BBookingDetails.Where(x=>x.CustomerId == id).Include(x=>x.Flight);

        foreach (var item in allbooking)
        {
            FullBookingDetails temp = new FullBookingDetails();

            temp.CustomerId = id;
            temp.FlightId = item.FlightId;
            temp.BookingId = item.BookingId;
            temp.BookedSeats = item.BookedSeats;
            temp.TotalCost = item.TotalCost;
            temp.Arrival = item.Flight.Arrival;
            temp.Departure = item.Flight.Departure;
            temp.Origin = item.Flight.Origin;
            temp.Destination = item.Flight.Destination;
            temp.FlightName = item.Flight.FlightName;
            newBooking.Add(temp);
        }
        return View(newBooking);
    }
}
