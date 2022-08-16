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
    public class TaskController : ControllerBase
    {
        private readonly PINBOARDContext _context;

        public TaskController(PINBOARDContext context)
        {
            _context = context;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taskinf>>> GetTaskinf()
        {
            return await _context.Taskinf
                .Include(x => x.AssignedbyNavigation)
                .Include(x => x.CreatedbyNavigation)
                .Include(x => x.AssignedtoNavigation)

                .ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taskinf>> GetTaskinf(int id)
        {
            var taskinf = await _context.Taskinf.FindAsync(id);

            if (taskinf == null)
            {
                return NotFound();
            }

            return taskinf;
        }

        // PUT: api/Task/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskinf(int id, Taskinf taskinf)
        {
            if (id != taskinf.Taskcode)
            {
                return BadRequest();
            }

            _context.Entry(taskinf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskinfExists(id))
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

        // POST: api/Task
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Taskinf>> PostTaskinf(Taskinf taskinf)
        {
            _context.Taskinf.Add(taskinf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskinf", new { id = taskinf.Taskcode }, taskinf);
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Taskinf>> DeleteTaskinf(int id)
        {
            var taskinf = await _context.Taskinf.FindAsync(id);
            if (taskinf == null)
            {
                return NotFound();
            }

            _context.Taskinf.Remove(taskinf);
            await _context.SaveChangesAsync();

            return taskinf;
        }

        private bool TaskinfExists(int id)
        {
            return _context.Taskinf.Any(e => e.Taskcode == id);
        }
    }
}
