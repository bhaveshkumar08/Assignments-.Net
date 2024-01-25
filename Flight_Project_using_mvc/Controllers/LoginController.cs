using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlightProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlightProject.Controllers;

public class LoginController : Controller
{
    // Dependency injection
    public static Ace52024Context db;
    private readonly ISession session;
    public LoginController(Ace52024Context _db, IHttpContextAccessor httpContextAccessor)
    {
        db = _db;
        session = httpContextAccessor.HttpContext.Session;
    }


   
    public IActionResult Login()
    {
        return View();
    }
        
    [HttpPost]
    // get and post action should have same name
    public IActionResult Login(BCustomer u){ //button click logic

        var result = (from i in db.BCustomers
                     where i.CustomerUsername == u.CustomerUsername && i.Password == u.Password
                     select i).SingleOrDefault();

        if(result != null){

            HttpContext.Session.SetString("Username", result.CustomerUsername);
            HttpContext.Session.SetInt32("UserId", result.CustomerId);
            return RedirectToAction("SearchFlights", "SearchFlights");
        }
        else{
            return View();
        }
    }



    public ActionResult Logout(){
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }



    public IActionResult Register()
    {
        return View();
    }
     
    [HttpPost]
    public IActionResult RegisterUser(BCustomer u){ 

        db.BCustomers.Add(u);
        db.SaveChanges();
        return RedirectToAction("Login");
    }
}
