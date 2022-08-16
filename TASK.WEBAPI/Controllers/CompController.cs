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
    public class CompController : ControllerBase
    {
        private readonly PINBOARDContext _context;

        public CompController(PINBOARDContext context)
        {
            _context = context;
        }

        // GET: api/Comp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compinf>>> GetCompinf()
        {
            return await _context.Compinf.ToListAsync();
        }

        // GET: api/Comp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compinf>> GetCompinf(string id)
        {
            var compinf = await _context.Compinf.FindAsync(id);

            if (compinf == null)
            {
                return NotFound();
            }

            return compinf;
        }

        // PUT: api/Comp/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompinf(string id, Compinf compinf)
        {
            if (id != compinf.Comcod)
            {
                return BadRequest();
            }

            _context.Entry(compinf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompinfExists(id))
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

        // POST: api/Comp
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Compinf>> PostCompinf(Compinf compinf)
        {
            _context.Compinf.Add(compinf);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompinfExists(compinf.Comcod))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompinf", new { id = compinf.Comcod }, compinf);
        }

        // DELETE: api/Comp/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Compinf>> DeleteCompinf(string id)
        {
            var compinf = await _context.Compinf.FindAsync(id);
            if (compinf == null)
            {
                return NotFound();
            }

            _context.Compinf.Remove(compinf);
            await _context.SaveChangesAsync();

            return compinf;
        }

        private bool CompinfExists(string id)
        {
            return _context.Compinf.Any(e => e.Comcod == id);
        }
    }
}
