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
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly ACE42023Context _context;

        public FlightController(ACE42023Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAllFlights")]
        public async Task<ActionResult<IEnumerable<FlightAvani>>> GetFlightAvanis()
        {
            return await _context.FlightAvanis.ToListAsync();
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<FlightAvani>> GetFlightAvani(int id)
        {
            var flightAvani = await _context.FlightAvanis.FindAsync(id);

            if (flightAvani == null)
            {
                return NotFound();
            }

            return flightAvani;
        }

    }
}
