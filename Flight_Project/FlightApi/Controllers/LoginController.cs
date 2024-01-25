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
    public class LoginController : ControllerBase
    {
        private readonly Ace52024Context _context;

        public LoginController(Ace52024Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<BCustomer>> Login(BCustomer u)
        {
            var result = (from i in _context.BCustomers
                     where i.CustomerUsername == u.CustomerUsername && i.Password == u.Password
                     select i).SingleOrDefault();

            if(result == null){
                return BadRequest();
            }
            
            return result;            
        }

        [HttpPost]
        [Route("LoginAdmin")]
        public async Task<ActionResult<Badmin>> LoginAdmin(Badmin u)
        {
            var result = (from i in _context.Badmins
                     where i.AdminName == u.AdminName && i.Password == u.Password
                     select i).SingleOrDefault();

            if(result == null){
                return BadRequest();
            }
            
            return result;            
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(BCustomer u)
        {
            
            try{
                _context.BCustomers.Add(u);
                await _context.SaveChangesAsync();  
            }   
            catch(DbUpdateConcurrencyException){
                return BadRequest();
            }

            return NoContent();         
        }    

    }
}
