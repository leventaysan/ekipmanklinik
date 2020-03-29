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
    public class EkipmanController : ControllerBase
    {
        private readonly APIDBContext _context;

        public EkipmanController(APIDBContext context)
        {
            _context = context;
        }

        // GET: api/Ekipman
        [HttpGet]
        public IEnumerable<Ekipman> GetEkipmans()
        {
            return _context.Ekipmans;
        }

        // GET: api/Ekipman/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEkipman([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ekipman = await _context.Ekipmans.FindAsync(id);

            if (ekipman == null)
            {
                return NotFound();
            }

            return Ok(ekipman);
        }

        // PUT: api/Ekipman/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEkipman([FromRoute] int id, [FromBody] Ekipman ekipman)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ekipman.EkipmanID)
            {
                return BadRequest();
            }

            _context.Entry(ekipman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EkipmanExists(id))
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

        // POST: api/Ekipman
        [HttpPost]
        public async Task<IActionResult> PostEkipman([FromBody] Ekipman ekipman)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ekipmans.Add(ekipman);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEkipman", new { id = ekipman.EkipmanID }, ekipman);
        }

        // DELETE: api/Ekipman/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEkipman([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ekipman = await _context.Ekipmans.FindAsync(id);
            if (ekipman == null)
            {
                return NotFound();
            }

            _context.Ekipmans.Remove(ekipman);
            await _context.SaveChangesAsync();

            return Ok(ekipman);
        }

        private bool EkipmanExists(int id)
        {
            return _context.Ekipmans.Any(e => e.EkipmanID == id);
        }
    }
}