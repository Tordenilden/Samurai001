using Microsoft.AspNetCore.Mvc;
using Samurai001.Repository.Interfaces;
using Samurai001.Repository.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Samurai001.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraiController : ControllerBase
    {
        public IRepository<Samurai> repository { get; set; }
        public SamuraiController(IRepository<Samurai> database)
        {
            repository = database;
        }

        //async Task<IEnumerable<T>> GetAll()
        // GET: api/<HorseController>
        [HttpGet]
        public async Task<IEnumerable<Samurai>> GetAll()
        {
            return await repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Samurai>> GetById(int id)
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
        public async Task<ActionResult<Samurai>> Create(Samurai obj)
        {
            try
            {
                if (obj == null) return BadRequest("The object is null");
                await repository.Create(obj);
                return CreatedAtAction("Create", new { id = obj.Id }, obj);
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

        //// PUT api/<HorseController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<HorseController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


        //// GET api/<HorseController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
    }
}

