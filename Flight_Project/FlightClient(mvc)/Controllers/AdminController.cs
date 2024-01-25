using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlightProject.Models; 
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using Newtonsoft.Json;

namespace FlightProject.Controllers;

public class AdminController : Controller
{
    // Dependency injection
    private readonly ISession session;
    public AdminController(IHttpContextAccessor httpContextAccessor)
    {
        session = httpContextAccessor.HttpContext.Session;
    }

   
    public async Task<IActionResult> GetAllCustomers()
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }

        List<BCustomer> allCust = new List<BCustomer>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5290/api/Admin/AllCustomers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    allCust = JsonConvert.DeserializeObject<List<BCustomer>>(apiResponse);
                }
            }
        
        return View(allCust);
    }

    public async Task<IActionResult> GetAllFlights()
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }
        List<BFlight> allFlights = new List<BFlight>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5290/api/Admin/AllFlights"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    allFlights = JsonConvert.DeserializeObject<List<BFlight>>(apiResponse);
                }
            }
        return View(allFlights);
    }

    public async Task<IActionResult> GetAllBookings()
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }
        List<BBookingDetail> allBookings = new List<BBookingDetail>();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5290/api/Admin/AllBookings"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                allBookings = JsonConvert.DeserializeObject<List<BBookingDetail>>(apiResponse);
            }
        }
        return View(allBookings);
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
    public async Task<IActionResult> AddNewFlights(BFlight newFlight)
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }

        using (var httpClient = new HttpClient())
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(newFlight), 
            Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("http://localhost:5290/api/Admin/AddNewFlight", content))
            {
                if(response.IsSuccessStatusCode){
                    return RedirectToAction("GetAllFlights");
                }
            }
        }
        return RedirectToAction("AddNewFlights");
    }


    public async Task<IActionResult> EditFlight(int id)
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }

        BFlight editFlights = new BFlight();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5290/api/Admin/EditFlight?id="+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    editFlights = JsonConvert.DeserializeObject<BFlight>(apiResponse);
                }
            }
        return View(editFlights);
    }

    [HttpPost]
    public async Task<IActionResult> EditFlight(BFlight newFlight)
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }
        using (var httpClient = new HttpClient())
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(newFlight), 
            Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("http://localhost:5290/api/Admin/EditFlightConfrim", content))
            {
                if(response.IsSuccessStatusCode){
                    return RedirectToAction("GetAllFlights");
                }
            }
        }
        return RedirectToAction("EditFlight");
    }

    // Delete Flight:
    public async Task<IActionResult> DeleteFlight(int id){
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }
        BFlight deleteFlights = new BFlight();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5290/api/Admin/DeleteFlight?id="+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    deleteFlights = JsonConvert.DeserializeObject<BFlight>(apiResponse);
                }
            }
        return View(deleteFlights);
    }

    [HttpPost]
    [ActionName("DeleteFlight")]
    public async Task<IActionResult> DeleteFlightConfirm(int id)
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.DeleteAsync("http://localhost:5290/api/Admin/DeleteFlightConfrim?id="+id))
            {
                if(response.IsSuccessStatusCode){
                    return RedirectToAction("GetAllFlights");
                }
            }
        }
        return RedirectToAction("DeleteFlight");
    }


    public async Task<IActionResult> CancelBooking(int id)
    {
        ViewBag.username = HttpContext.Session.GetString("Adminname");
        if(ViewBag.username == null){
            return RedirectToAction("LogIn");   
        }
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.DeleteAsync("http://localhost:5290/api/Admin/CancelFlight?id="+id))
            {
                if(response.IsSuccessStatusCode){
                    return RedirectToAction("GetAllBookings");
                }
            }
        }
        return RedirectToAction("GetAllBookings");
    }


    public IActionResult LogIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(Badmin admin)
    {
        using (var client = new HttpClient())
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(admin), 
            Encoding.UTF8, "application/json");
            Badmin c = new Badmin();
            using (var response = await client.PostAsync("http://localhost:5290/api/Login/LoginAdmin", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        c = JsonConvert.DeserializeObject<Badmin>(apiResponse);

                        HttpContext.Session.SetString("Adminname", c.AdminName);
                    }
                    else{
                        // return NotFound();
                        return RedirectToAction("LogIn");
                    }
                }
                return RedirectToAction("GetAllFlights");
            }  
    }

    public IActionResult LogOut(){
        HttpContext.Session.Clear();
        return RedirectToAction("LogIn");
    }
    
}