using BELibreria.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BELibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public LibrosController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<LibrosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listLibros = await _context.Libreria.ToListAsync();
                return Ok(listLibros);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LibrosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Libro libro)
        {
            try
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return Ok(libro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LibrosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
            try
            {
                var libroBorrar = await _context.Libreria.FindAsync(id);

                if(libroBorrar == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Libreria.Remove(libroBorrar);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = " El libro fue eliminado con exito" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
