using System.Diagnostics; 
using Microsoft.AspNetCore.Mvc;
using FlightProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Text;

namespace FlightProject.Controllers;

public class ProfileController : Controller
{
    // Dependency injection
    private readonly ISession session;
    public ProfileController(IHttpContextAccessor httpContextAccessor)
    {
        session = httpContextAccessor.HttpContext.Session;
    }

    
    public async Task<IActionResult> ProfileDetail()
    {
        int? id = HttpContext.Session.GetInt32("UserId");
        if(id == null){
            return RedirectToAction("Login", "Login");   
        }
        
        BCustomer prof = new BCustomer();
        using (var httpClient = new HttpClient())
        {
            try{
                using (var response = await httpClient.GetAsync("http://localhost:5290/api/Profile?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    prof = JsonConvert.DeserializeObject<BCustomer>(apiResponse);
                }
            }
            catch(Exception ex){
                return RedirectToAction("Error", "Home");
            }
        }
        return View(prof);
    }

    
    public async Task<IActionResult> EditProfileDetail(int id)
    {
        int? i = HttpContext.Session.GetInt32("UserId");
        if(i == null){
            return RedirectToAction("Login", "Login");   
        }
        BCustomer prof = new BCustomer();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5290/api/Profile/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                prof = JsonConvert.DeserializeObject<BCustomer>(apiResponse);
            }
        }
        return View(prof);
    }

        
    [HttpPost]
    public async Task<IActionResult> EditProfileDetail(BCustomer u)
    {
        int? id = HttpContext.Session.GetInt32("UserId");
        if(id == null){
            return RedirectToAction("Login", "Login");   
        }
// Console.WriteLine(")))))))************************enter*************************(((((((((((())))))))))))");
        
        using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), 
                Encoding.UTF8, "application/json");
                // Console.WriteLine(")))))))************************call*************************(((((((((((())))))))))))");

                using (var response = await client.PutAsync("http://localhost:5290/api/Profile/"+id, content))
                {
                    // Console.WriteLine(")))))))************************return*************************(((((((((((())))))))))))");

                    if(response.StatusCode ==System.Net.HttpStatusCode.NoContent){
                        return RedirectToAction("ProfileDetail");
                        // Console.WriteLine(")))))))************************here*************************(((((((((((())))))))))))");
                    }
                    else{
                        // return NotFound();
                        return View();
                    }
                }
            }
    }   
    
}
