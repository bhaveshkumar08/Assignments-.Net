using Microsoft.AspNetCore.Mvc;
using firstMVCPoject.Models;
using Microsoft.EntityFrameworkCore;

namespace firstMVCPoject.Controllers{
    public class SBAccountsController : Controller{
        // public SBAccountsController() { 

        // }
        // private static Ace52024Context db = new Ace52024Context();

        public static Ace52024Context db;
        
        //Dependency Injection  in constructor
        public SBAccountsController(Ace52024Context _db)
        {
            db=_db;
        }
        public IActionResult GetAllAccounts()
        {
            ViewBag.UserEmail = HttpContext.Session.GetString("User");
            if(ViewBag.UserEmail!=null){
                return View(db.BhaveshSbaccounts);
            }
            else{
                return RedirectToAction("Login","Login");
            }
        }

        [HttpGet]
        public IActionResult AddAccount(){//called when click on hyperlink in GetAllAccounts.cshtml view and this action then return the view file AddAccount.cshtml
            return View();
        }

        [HttpPost]
        // get and post action should have same name
        public IActionResult AddAccount(BhaveshSbaccount newAcc){ //button click logic

            db.BhaveshSbaccounts.Add(newAcc);
            db.SaveChanges();
            return RedirectToAction("GetAllAccounts");
        }

        public IActionResult AccountDetails(int Accno){

            var trans = db.BhaveshSbaccounts.Where(x=>x.AccountNumber == Accno).Include(x=>x.BhaveshSbtransactions);
            List<BhaveshSbtransaction> ThisAccTrans = new List<BhaveshSbtransaction>();
            foreach (var item in trans)
            {
                ViewBag.CustomerName = item.CustomerName;
                ViewBag.AccountNumber = item.AccountNumber;
                ViewBag.CurrentBalance = item.CurrentBalance;
                foreach (var i in item.BhaveshSbtransactions)
                {
                    ThisAccTrans.Add(i);
                }
            }
            return View(ThisAccTrans);  
        }

        public IActionResult EditAccountDetails(int Accno){
            BhaveshSbaccount? acc = db.BhaveshSbaccounts.Where(x=>x.AccountNumber == Accno).SingleOrDefault();

            return View(acc);  
        }

        [HttpPost]
        public IActionResult EditAccountDetails(BhaveshSbaccount NewDetails){
            db.BhaveshSbaccounts.Update(NewDetails);
            db.SaveChanges();
            return RedirectToAction("GetAllAccounts");  
        }

        public IActionResult DeleteAccount(int id){
            BhaveshSbaccount? acc = db.BhaveshSbaccounts.Where(x=>x.AccountNumber == id).SingleOrDefault();
            TempData["accde"] = id;
            return View(acc);  
        }

        [HttpPost]
        [ActionName("DeleteAccount")]
        public IActionResult DeleteAccountConfirmed(){
            int accd = (int)TempData["accde"];
            BhaveshSbaccount? acctodel = db.BhaveshSbaccounts.Where(x=>x.AccountNumber == accd).SingleOrDefault();
            db.BhaveshSbaccounts.Remove(acctodel);

            // BhaveshSbaccount? acctodel = db.BhaveshSbaccounts.Where(x=>x.AccountNumber == id).SingleOrDefault();
            // if(acctodel != null) db.BhaveshSbaccounts.Remove(acctodel);

            db.SaveChanges();
            return RedirectToAction("GetAllAccounts");  
        }

    }
}