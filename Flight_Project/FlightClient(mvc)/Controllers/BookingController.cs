using System.Diagnostics; 
using Microsoft.AspNetCore.Mvc;
using FlightProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

// namespace FlightProject.Controllers;

public class BookingController : Controller
{
    // Dependency injection
    private readonly ISession session;
    public BookingController(IHttpContextAccessor httpContextAccessor)
    {
        session = httpContextAccessor.HttpContext.Session;
    }


    public async Task<IActionResult> BookingConfirm(int id, int seats)
    {
        ViewBag.username = HttpContext.Session.GetString("Username");
        if(ViewBag.username == null){
            return RedirectToAction("Login", "Login");   
        }
            int? i = HttpContext.Session.GetInt32("UserId");

            FullBookingDetails BookingD = new FullBookingDetails();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5290/api/Booking?id=" + id + "&seats=" + seats + "&cid=" + i))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    BookingD = JsonConvert.DeserializeObject<FullBookingDetails>(apiResponse);
                }
            }
            return View(BookingD);
    }

        
    [HttpPost]
    // get and post action should have same name
    public async Task<IActionResult> BookingConfirm(FullBookingDetails f)
    {
        ViewBag.usename = HttpContext.Session.GetString("Username");
        if(ViewBag.usename == null){
            return RedirectToAction("Login", "Login");   
        }
        
        using (var httpClient = new HttpClient())
        {       
            StringContent content = new StringContent(JsonConvert.SerializeObject(f), 
            Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("http://localhost:5290/api/Booking", content))
            {
                if(response.IsSuccessStatusCode){
                    return RedirectToAction("BookingHistory");
                }

            }
        }
        return View(); 
    }
    
    public async Task<IActionResult> BookingHistory()
    {
        int? id = HttpContext.Session.GetInt32("UserId");
        if(id == null){
            return RedirectToAction("Login", "Login");   
        }
        List<FullBookingDetails> newBooking = new List<FullBookingDetails>();

        using (var httpClient = new HttpClient())
        {  
            using (var response = await httpClient.GetAsync("http://localhost:5290/api/Booking/"+ id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                newBooking = JsonConvert.DeserializeObject<List<FullBookingDetails>>(apiResponse);
            }
        }
        
        return View(newBooking);
    }
}
