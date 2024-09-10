using Microsoft.AspNetCore.Mvc;
using Samurai001.Repository.Interfaces;
using Samurai001.Repository.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Samurai001.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorseController : ControllerBase
    {
        public IRepository<Horse> repository { get; set; }
        public HorseController(IRepository<Horse> database)
        {
            repository = database;
        }
        #region get
        #endregion get
        #region get


        // GET: api/<HorseController>
        [HttpGet]
        public async Task<IEnumerable<Horse>> GetAll()
        {
            return await repository.GetAll();
        }

        [HttpGet("getallHTTP_codes")]
        public async Task<ActionResult<IEnumerable<Horse>>> getallHTTP_codes()
        {
            try
            {
                var result = await repository.GetAll(); // null forgiving operator
                if (result == null)
                {
                    // something has gone wrong serverside, return code 500
                    return Problem("Flemse Unexpected null returned from service");
                }
                else if (result.Count() == 0)
                {
                    // no data exists, but everything is still ok, return code 204
                    return NoContent();
                }
                // we got data! return with code 200
                return Ok(result);
            }
            catch (Exception ex)
            {
                // handle any other exeptions raised by sending code 500
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Horse>> GetById(int id)
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
        #endregion get
        // POST api/<HorseController>
        [HttpPost]
        public async Task<ActionResult<Horse>> Create( Horse h)
        {
            try
            {
                if (h == null) return BadRequest("The object is null");
                var temp = await repository.Create(h);
                return CreatedAtAction("Create", new { id = h.Id }, h);
            }
            catch (Exception e)
            {
                return Problem($"could not create{e.Message}");
            }
        }

        //// PUT api/<HorseController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

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


        //// GET api/<HorseController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
    }
}
