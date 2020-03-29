using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HastaneEkipman.Models;

namespace HastaneEkipman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlinikController : ControllerBase
    {
        private readonly APIDBContext _context;

        public KlinikController(APIDBContext context)
        {
            _context = context;
        }

        // GET: api/Klinik
        [HttpGet]
        public IEnumerable<Klinik> GetKliniks()
        {
            return _context.Kliniks;
        }

        // GET: api/Klinik/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKlinik([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var klinik = await _context.Kliniks.FindAsync(id);

            if (klinik == null)
            {
                return NotFound();
            }

            return Ok(klinik);
        }

        // PUT: api/Klinik/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKlinik([FromRoute] int id, [FromBody] Klinik klinik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != klinik.KlinikID)
            {
                return BadRequest();
            }

            _context.Entry(klinik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlinikExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Klinik
        [HttpPost]
        public async Task<IActionResult> PostKlinik([FromBody] Klinik klinik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Kliniks.Add(klinik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKlinik", new { id = klinik.KlinikID }, klinik);
        }

        // DELETE: api/Klinik/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKlinik([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var klinik = await _context.Kliniks.FindAsync(id);
            if (klinik == null)
            {
                return NotFound();
            }

            _context.Kliniks.Remove(klinik);
            await _context.SaveChangesAsync();

            return Ok(klinik);
        }

        private bool KlinikExists(int id)
        {
            return _context.Kliniks.Any(e => e.KlinikID == id);
        }
    }
}