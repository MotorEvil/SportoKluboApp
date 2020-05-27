using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportoKluboApp.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportoKluboAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<WorkoutController>
        [HttpGet]
        public IActionResult GetWorkouts()
        {
            return Ok(_context.Items);
        }

        // GET api/<WorkoutController>/5
        [HttpGet("{id}")]
        public SportoKluboApp.Models.Treniruote Get(Guid id)
        {
            return _context.Items.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<WorkoutController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WorkoutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WorkoutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
