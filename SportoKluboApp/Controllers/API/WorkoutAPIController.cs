using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportoKluboApp.Data;

namespace SportoKluboApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkoutAPIController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/WorkoutAPI
        [HttpGet]
        public IActionResult GetWorkouts()
        {
            return Ok(_context.Items);
        }

        // GET api/<WorkoutAPIController>/5
        [HttpGet("{id}")]
        public Models.Treniruote Get(Guid id)
        {
            return _context.Items.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<WorkoutAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WorkoutAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WorkoutAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
