using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlightProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace FlightProject.Controllers;

public class SearchFlightsController : Controller
{
     public async Task<ActionResult> SearchFlights()
        {
            List<BLocation> Locations = new List<BLocation>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllCustomer using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("http://localhost:5290/api/SearchFlight");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var LocationResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Locations = JsonConvert.DeserializeObject<List<BLocation>>(LocationResponse);

                }
                 ViewBag.Origins = new SelectList(Locations, "Locations", "Locations");
                return View();
            }
        }
       

        [HttpPost]
        public async Task<ActionResult> SearchResults(SearchCapture s )
        {
            ViewBag.Seats = s.seats;
            List<BFlight> flightMatch = new List<BFlight>();
            using (var httpClient = new HttpClient())
            {
              
              StringContent content = new StringContent(JsonConvert.SerializeObject(s), 
              Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:5290/api/SearchFlight", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    flightMatch = JsonConvert.DeserializeObject<List<BFlight>>(apiResponse);
                }
            }
            if(flightMatch.Count == 0){
            ViewBag.count = 0;
            }
           
            return View(flightMatch);
        }
}
