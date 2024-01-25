using Microsoft.AspNetCore.Mvc;
using firstMVCPoject.Models;

namespace firstMVCPoject.Controllers{
    public class LoginController : Controller{
        
        //Dependency Injection  in constructor
        public static Ace52024Context db;

         private readonly ISession session;
        public LoginController(Ace52024Context _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }
        
        // public LoginController(Ace52024Context _db)
        // {
        //     db=_db;
        // }
        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        // get and post action should have same name
        public IActionResult Login(BhaveshUser u){ //button click logic

            var result = (from i in db.BhaveshUsers
                         where i.EmailId == u.EmailId && i.Password == u.Password
                         select i).SingleOrDefault();

            if(result != null){

                HttpContext.Session.SetString("User", result.EmailId);
                return RedirectToAction("GetAllAccounts", "SBAccounts");
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
        // get and post action should have same name
        public IActionResult RegisterUser(BhaveshUser u){ //button click logic

            db.BhaveshUsers.Add(u);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

    }
}