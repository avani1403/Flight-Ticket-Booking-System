using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiflight.Models;

namespace apiflight.Controllers
{
    public class LoginException : ApplicationException
    {
        public LoginException(string message) : base(message)
        {

        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ACE42023Context _context;

        public LoginController(ACE42023Context context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("get/{id}")]  //api/Login/get/5
        public async Task<ActionResult<FlightuserAvani>> GetFlightuserAvani(int id)
        {
            var flightuserAvani = await _context.FlightuserAvanis.FindAsync(id);

            if (flightuserAvani == null)
            {
                return NotFound();
            }

            return flightuserAvani;
        }

    
        [HttpPost]
        [Route("register")] //api/Login/register
        public async Task<ActionResult<FlightuserAvani>> PostFlightuserAvani(FlightuserAvani obj)
        {
            
            if(_context.FlightuserAvanis == null)
            {
                return Problem("Entity set 'ACE42023Context.FlightuserAvanis' is null.");
            }
            try{
                foreach(var userexist in _context.FlightuserAvanis)
                {
                    if(userexist.Userid == obj.Userid)
                    {
                        throw new LoginException("The UserId already exists, try again with a unique UserId.");
                    }
                }
                _context.FlightuserAvanis.Add(obj);
                await _context.SaveChangesAsync();
            }
        
            catch(Exception e)
            {
                return Conflict(e.Message);
            }
            return CreatedAtAction("GetFlightuserAvani", new{id=obj.Userid},obj);
        }

    }
}
