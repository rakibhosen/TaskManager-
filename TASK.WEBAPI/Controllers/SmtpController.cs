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
    public class SmtpController : ControllerBase
    {
        private readonly PINBOARDContext _context;

        public SmtpController(PINBOARDContext context)
        {
            _context = context;
        }

        // GET: api/Smtp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Smtpinf>>> GetSmtpinf()
        {
            return await _context.Smtpinf.ToListAsync();
        }

        // GET: api/Smtp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Smtpinf>> GetSmtpinf(int id)
        {
            var smtpinf = await _context.Smtpinf.FindAsync(id);

            if (smtpinf == null)
            {
                return NotFound();
            }

            return smtpinf;
        }

        // PUT: api/Smtp/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmtpinf(int id, Smtpinf smtpinf)
        {
            if (id != smtpinf.Smtpid)
            {
                return BadRequest();
            }

            _context.Entry(smtpinf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmtpinfExists(id))
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

        // POST: api/Smtp
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Smtpinf>> PostSmtpinf(Smtpinf smtpinf)
        {
            _context.Smtpinf.Add(smtpinf);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SmtpinfExists(smtpinf.Smtpid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSmtpinf", new { id = smtpinf.Smtpid }, smtpinf);
        }

        // DELETE: api/Smtp/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Smtpinf>> DeleteSmtpinf(int id)
        {
            var smtpinf = await _context.Smtpinf.FindAsync(id);
            if (smtpinf == null)
            {
                return NotFound();
            }

            _context.Smtpinf.Remove(smtpinf);
            await _context.SaveChangesAsync();

            return smtpinf;
        }

        private bool SmtpinfExists(int id)
        {
            return _context.Smtpinf.Any(e => e.Smtpid == id);
        }
    }
}
