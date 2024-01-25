using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightApi.Models;

namespace FlightApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchFlightController : ControllerBase
    {
        private readonly Ace52024Context _context;

        public SearchFlightController(Ace52024Context context)
        {
            _context = context;
        }

        // GET: api/SearchFlight
        // **********************This will called when click on search and this will return Search Location object
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLocation>>> GetSearch()
        {

            return await _context.BLocations.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<BFlight>>> PostSeachResult(SearchCapture s)
        {
            List<BFlight> temp = new List<BFlight>();
            foreach (var item in _context.BFlights)
            {
                if(item.Origin == s.origin && item.Destination == s.destination && item.Departure == s.departure){
                    temp.Add(item);
                }
            }
            return temp;
            
        }

    }
}
