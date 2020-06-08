using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportoKluboApp.Data;
using SportoKluboApp.Models;

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
            return Ok(_context.Items.OrderBy(x => x.Laikas));
        }

        // GET api/<WorkoutController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Treniruote>> Get(Guid id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST api/<WorkoutController>
        [HttpPost]
        public async Task<ActionResult<Treniruote>> Post(Treniruote newtreniruote)
        {
            var item = new Treniruote
            {
                Id = Guid.NewGuid(),
                Registracijos = 0,
                IsDone = false,
                TreniruotesDalyviai = "",
                Pavadinimas = newtreniruote.Pavadinimas,
                Laikas = newtreniruote.Laikas,
                LaisvosVietos = newtreniruote.LaisvosVietos
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = newtreniruote.Id }, newtreniruote);

        }

        // PUT api/<WorkoutController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Treniruote treniruote)
        {
            if (id != treniruote.Id)
            {
                return BadRequest();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Pavadinimas = treniruote.Pavadinimas;
            item.Laikas = treniruote.Laikas;
            item.IsDone = treniruote.IsDone;
            item.LaisvosVietos = treniruote.LaisvosVietos;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ItemExists(id))
            {

                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<WorkoutController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(Guid id) =>
            _context.Items.Any(x => x.Id == id);
    }
}
