using Microsoft.AspNetCore.Mvc;
using firstMVCPoject.Models;
using Microsoft.EntityFrameworkCore;

namespace firstMVCPoject.Controllers{
    public class CustomerController : Controller{
         public static Ace52024Context db;
        
        //Dependency Injection  in constructor
        public CustomerController(Ace52024Context _db)
        {
            db=_db;
        }
        public IActionResult GetAllCustomers(){
            return View(db.CustomerBks);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        // get and post action should have same name
        public IActionResult AddCustomer(CustomerBk c){ //button click logic

            if(ModelState.IsValid){
                db.CustomerBks.Add(c);
                db.SaveChanges();
                return RedirectToAction("GetAllCustomers");
            }
            else{
                return View();
            }
        }

    }
}