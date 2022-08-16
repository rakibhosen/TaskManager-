using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TASK.WEBAPI.Models;

namespace TASK.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GinfController : ControllerBase
    {
        private readonly PINBOARDContext _context;

        public GinfController(PINBOARDContext context)
        {
            _context = context;
        }

        // GET: api/Ginf
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ginf>>> GetGinf()
        {
            return await _context.Ginf.ToListAsync();
        }

        // GET: api/Ginf/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ginf>> GetGinf(string id)
        {
            var ginf = await _context.Ginf.FindAsync(id);

            if (ginf == null)
            {
                return NotFound();
            }

            return ginf;
        }

        // PUT: api/Ginf/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGinf(string id, Ginf ginf)
        {
            if (id != ginf.Gcod)
            {
                return BadRequest();
            }

            _context.Entry(ginf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GinfExists(id))
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

        // POST: api/Ginf
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ginf>> PostGinf(Ginf ginf)
        {
            _context.Ginf.Add(ginf);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GinfExists(ginf.Gcod))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGinf", new { id = ginf.Gcod }, ginf);
        }

        // DELETE: api/Ginf/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ginf>> DeleteGinf(string id)
        {
            var ginf = await _context.Ginf.FindAsync(id);
            if (ginf == null)
            {
                return NotFound();
            }

            _context.Ginf.Remove(ginf);
            await _context.SaveChangesAsync();

            return ginf;
        }

        private bool GinfExists(string id)
        {
            return _context.Ginf.Any(e => e.Gcod == id);
        }
    }
}
