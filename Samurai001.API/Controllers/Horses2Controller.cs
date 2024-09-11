using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Samurai001.Repository.Interfaces;
using Samurai001.Repository.Models;

namespace Samurai001.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Horses2Controller : ControllerBase
    {
        private readonly IGeneric<Horse> _context;

        public Horses2Controller(IGeneric<Horse> context)
        {
            _context = context;
        }

        // GET: api/Horses2
        [HttpGet]
        public ActionResult<IEnumerable<Horse>> Get()
        {
            return  Ok(_context.getAll());
            //return Ok(_context.getById(5))
        }

        //// GET: api/Horses2/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Horse>> GetHorse(int id)
        //{
        //    var horse = await _context.Horse.FindAsync(id);

        //    if (horse == null)
        //    {
        //        return NotFound();
        //    }

        //    return horse;
        //}

        //// PUT: api/Horses2/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutHorse(int id, Horse horse)
        //{
        //    if (id != horse.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(horse).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!HorseExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Horses2
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Horse>> PostHorse(Horse horse)
        //{
        //    _context.Horse.Add(horse);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetHorse", new { id = horse.Id }, horse);
        //}

        //// DELETE: api/Horses2/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteHorse(int id)
        //{
        //    var horse = await _context.Horse.FindAsync(id);
        //    if (horse == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Horse.Remove(horse);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool HorseExists(int id)
        //{
        //    return _context.Horse.Any(e => e.Id == id);
        //}
    }
}
