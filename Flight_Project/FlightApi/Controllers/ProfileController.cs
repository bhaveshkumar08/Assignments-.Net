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
    public class ProfileController : ControllerBase
    {
        private readonly Ace52024Context _context;

        public ProfileController(Ace52024Context context)
        {
            _context = context;
        }

        // GET: api/Profile
        [HttpGet]
        public async Task<ActionResult<BCustomer>> GetCustomer(int id)
        {
            var bCustomer = await _context.BCustomers.FindAsync(id);
            if (bCustomer == null)
            {
                return NotFound();
            }

            return bCustomer;
        }

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BCustomer>> EditCustomerDetails(int id)
        {
            var bCustomer = await _context.BCustomers.FindAsync(id);

            if (bCustomer == null)
            {
                return NotFound();
            }

            return bCustomer;
        }

        // PUT: api/Profile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerDetails(int id, BCustomer bCustomer)
        {
            if (id != bCustomer.CustomerId)
            {
                return BadRequest();
            }

            _context.BCustomers.Update(bCustomer);
            // Console.WriteLine(")))))))************************update*************************(((((((((((())))))))))))");


            try
            {
                await _context.SaveChangesAsync();
                // Console.WriteLine(")))))))************************savechanges*************************(((((((((((())))))))))))");

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BCustomerExists(id))
                {
                    // Console.WriteLine(")))))))************************if*************************(((((((((((())))))))))))");

                    return NotFound();
                }
                else
                {
                    // Console.WriteLine(")))))))************************here*************************(((((((((((())))))))))))");

                    throw;
                }
            }

            return NoContent();
        }

        private bool BCustomerExists(int id)
        {
            return _context.BCustomers.Any(e => e.CustomerId == id);
        }
    }
}
