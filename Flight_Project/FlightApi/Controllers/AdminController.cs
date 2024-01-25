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
    public class AdminController : ControllerBase
    {
        private readonly Ace52024Context _context;

        public AdminController(Ace52024Context context)
        {
            _context = context;
        }



        // GET: api/Admin
        [HttpGet]
        [Route("AllCustomers")]
        public async Task<ActionResult<IEnumerable<BCustomer>>> GetAllCustomers()
        {
            return await _context.BCustomers.ToListAsync();
        }
        [HttpGet]
        [Route("AllBookings")]
        public async Task<ActionResult<IEnumerable<BBookingDetail>>> GetAllBooings()
        {
            return await _context.BBookingDetails.ToListAsync();
        }
        [HttpGet]
        [Route("AllFlights")]
        public async Task<ActionResult<IEnumerable<BFlight>>> GetAllFlights()
        {
            return await _context.BFlights.ToListAsync();
        }

        // POST: api/Admin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("AddNewFlight")]
        public async Task<ActionResult> PostAddNewFlight(BFlight n)
        {   
            var newLoc = _context.BLocations.Where(x => x.Locations == n.Origin).SingleOrDefault();
            if(newLoc == null){
                BLocation nL = new BLocation();
                nL.Locations = n.Origin;
                _context.BLocations.Add(nL);
            }
            newLoc = _context.BLocations.Where(x => x.Locations == n.Destination).SingleOrDefault();
            if(newLoc == null){
                BLocation nL = new BLocation();
                nL.Locations = n.Destination;
                _context.BLocations.Add(nL);
            }

            _context.BFlights.Add(n);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("EditFlight")]
        public async Task<ActionResult<BFlight>> GetFlightsToEdit(int id)
        {   
            var FlightToEdit = await _context.BFlights.FindAsync(id);
            if (FlightToEdit == null)
            {
                return NotFound();
            }
            return FlightToEdit;
        }

        [HttpPost]
        [Route("EditFlightConfrim")]
        public async Task<ActionResult> PostFlightEditConf(BFlight newFlight)
        {   
            _context.BFlights.Update(newFlight);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("DeleteFlight")]
        public async Task<ActionResult<BFlight>> GetFlightsToDelete(int id)
        {   
            var FlightToDelete = await _context.BFlights.FindAsync(id);
            if (FlightToDelete == null)
            {
                return NotFound();
            }
            return FlightToDelete;
        }

        [HttpDelete]
        [Route("DeleteFlightConfrim")]
        public async Task<ActionResult> FlightDeleteConf(int id)
        {   
            var FlightToDelete = await _context.BFlights.FindAsync(id);

            if (FlightToDelete == null)
            {
                return NotFound();
            }

            _context.BFlights.Remove(FlightToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        [HttpDelete]
        [Route("CancelFlight")]
        public async Task<ActionResult> CancelFlight(int id)
        {   
            var cancelB= _context.BBookingDetails.Where(x=> x.BookingId == id).SingleOrDefault();
            var changeFlight = _context.BFlights.Where(b => b.FlightId == cancelB.FlightId).Select(b=>b).SingleOrDefault();
            changeFlight.SeatAvailable += cancelB.BookedSeats;
            _context.BFlights.Update(changeFlight);
            _context.BBookingDetails.Remove(cancelB);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }
}
