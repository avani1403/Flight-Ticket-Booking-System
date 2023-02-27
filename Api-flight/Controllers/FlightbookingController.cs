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
    public class FlightbookingController : ControllerBase
    {
        private readonly ACE42023Context _context;

        public FlightbookingController(ACE42023Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getBookings")]  // api/Flightbooking/getBookings
        public async Task<ActionResult<IEnumerable<FlightbookingAvani>>> GetFlightbookingAvanis()
        {
            return await _context.FlightbookingAvanis.ToListAsync();
        }

        [HttpGet]
        [Route("getBookingsOfId/{id}")]  // api/Flightbooking/getBookingsOfId/1101
        public async Task<ActionResult<FlightbookingAvani>> GetFlightbookingAvani(int id)
        {
            var flightbookingAvani = await _context.FlightbookingAvanis.FindAsync(id);

            if (flightbookingAvani == null)
            {
                return NotFound();
            }

            return flightbookingAvani;
        }

        [HttpPut]
        [Route("edit/{id}")]  // api/Flightbooking/edit/1101
        public async Task<IActionResult> PutFlightbookingAvani(int id, FlightbookingAvani flightbookingAvani)
        {
            if (id != flightbookingAvani.Bid)
            {
                return BadRequest();
            }

            _context.Entry(flightbookingAvani).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightbookingAvaniExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return  Ok(flightbookingAvani);
        }

        [HttpPost]
        [Route("addBooking")]    // api/Flightbooking/addBooking
        public async Task<ActionResult<FlightbookingAvani>> PostFlightbookingAvani(FlightbookingAvani flightbookingAvani)
        {
            _context.FlightbookingAvanis.Add(flightbookingAvani);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlightbookingAvaniExists(flightbookingAvani.Bid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFlightbookingAvani", new { id = flightbookingAvani.Bid }, flightbookingAvani);
        }


        [HttpDelete]
        [Route("delete/{id}")]  // api/Flightbooking/delete/1101
        public async Task<IActionResult> DeleteFlightbookingAvani(int id)
        {
            var flightbookingAvani = await _context.FlightbookingAvanis.FindAsync(id);
            if (flightbookingAvani == null)
            {
                return NotFound();
            }

            _context.FlightbookingAvanis.Remove(flightbookingAvani);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightbookingAvaniExists(int id)
        {
            return _context.FlightbookingAvanis.Any(e => e.Bid == id);
        }
    }
}
