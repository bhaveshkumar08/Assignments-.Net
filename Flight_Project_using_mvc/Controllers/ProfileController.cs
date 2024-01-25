using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlightProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FlightProject.Controllers;

public class ProfileController : Controller
{
    // Dependency injection
    public static Ace52024Context db;
    private readonly ISession session;
    public ProfileController(Ace52024Context _db, IHttpContextAccessor httpContextAccessor)
    {
        db = _db;
        session = httpContextAccessor.HttpContext.Session;
    }

   
    public IActionResult ProfileDetail()
    {
        int? id = HttpContext.Session.GetInt32("UserId");
        if(id == null){
            return RedirectToAction("Login", "Login");   
        }
        
        BCustomer prof = db.BCustomers.Where(x => x.CustomerId == id).FirstOrDefault();
        return View(prof);
    }

    public IActionResult EditProfileDetail(int id)
    {
        int? i = HttpContext.Session.GetInt32("UserId");
        if(i == null){
            return RedirectToAction("Login", "Login");   
        }
        BCustomer prof = db.BCustomers.Where(x => x.CustomerId == id).FirstOrDefault();
        return View(prof);
    }

        
    [HttpPost]
    public IActionResult EditProfileDetail(BCustomer f)
    {
        if(ModelState.IsValid){
            db.BCustomers.Update(f);
            db.SaveChanges();
            return RedirectToAction("ProfileDetail");
        }
        else{
            return View();
        }
    }   
    
}
