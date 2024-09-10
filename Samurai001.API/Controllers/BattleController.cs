using Microsoft.AspNetCore.Mvc;
using Samurai001.Repository.Interfaces;
using Samurai001.Repository.Models;

namespace Samurai001.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        public IRepository<Battle> repository { get; set; }
        public BattleController(IRepository<Battle> database)
        {
            repository = database;
        }

        //async Task<IEnumerable<T>> GetAll()
        // GET: api/<HorseController>
        [HttpGet]
        public async Task<IEnumerable<Battle>> GetAll()
        {
            return await repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Battle>> GetById(int id)
        {
            try
            {
                var result = await repository.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // POST api/<HorseController>
        [HttpPost]
        public async Task<ActionResult<Battle>> Create(Battle h)
        {
            try
            {
                if (h == null) return BadRequest("The object is null");
                await repository.Create(h);
                return CreatedAtAction("Create", new { id = h.Id }, h);
            }
            catch (Exception e)
            {
                return Problem($"could not create{e.Message}");
            }
        }


        // DELETE api/<HorseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await repository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            var t = repository.Delete(result).Result;
            return NoContent();
        }


        //// POST api/<HorseController>
        //[HttpPost]
        //public async Task<ActionResult<Horse>> Create(Horse h)
        //{
        //    try
        //    {
        //        if (h == null) return BadRequest("The object is null");
        //        await repository.Create(h);
        //        return CreatedAtAction("Create", new { id = h.HorseId }, h);
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem($"could not create{e.Message}");
        //    }
        //}
    }
}
