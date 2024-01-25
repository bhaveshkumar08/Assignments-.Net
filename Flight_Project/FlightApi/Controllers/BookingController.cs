using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightApi.Models;
using FlightProject.Models;
using firstapi.Repository;
using firstapi.Service;

namespace FlightApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingSer<BBookingDetail> _context;

        public BookingController(IBookingSer<BBookingDetail> context)
        {
            _context = context;
        }

        // GET: api/Booking
        [HttpGet]
        public async Task<ActionResult<FullBookingDetails>> GetBookingDetails(int id, int seats,int cid)
        {
            return await _context.BookingDetails(id, seats, cid);
        }

        // POST: api/Booking
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostBookingConfirm(FullBookingDetails f)
        {
            await _context.BookingConfirm(f);   
            return Ok();   
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FullBookingDetails>>> GetBookingHistory(int id)
        {   
            return await _context.BookingHistory(id);
        }

    }
}
