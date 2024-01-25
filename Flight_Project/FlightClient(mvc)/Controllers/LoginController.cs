using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlightProject.Models; 
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FlightProject.Controllers;

public class LoginController : Controller
{
    // Dependency injection
    private readonly ISession session;
    public LoginController(IHttpContextAccessor httpContextAccessor)
    {
        session = httpContextAccessor.HttpContext.Session;
    }

 
    public IActionResult Login()
    {
        return View();
    }
        
    [HttpPost]
    // get and post action should have same name
    public async Task<IActionResult> Login(BCustomer u){ //button click logic

        using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), 
                Encoding.UTF8, "application/json");
                BCustomer c = new BCustomer();
                using (var response = await client.PostAsync("http://localhost:5290/api/Login", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        c = JsonConvert.DeserializeObject<BCustomer>(apiResponse);

                        HttpContext.Session.SetInt32("UserId", c.CustomerId);
                        HttpContext.Session.SetString("Username", c.CustomerName);
                    }
                    else{
                        // return NotFound();
                        return View();
                    }
                }
                return RedirectToAction("SearchFlights","SearchFlights");
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
    public async Task<IActionResult> RegisterUser(BCustomer u){ 

        using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), 
                Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("http://localhost:5290/api/Login/Register", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Login");
                    }
                    else{
                        return View();
                    }
                }
            }
    }
}
