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
    public class ChatlogsController : ControllerBase
    {
        private readonly PINBOARDContext _context;

        public ChatlogsController(PINBOARDContext context)
        {
            _context = context;
        }

        // GET: api/Chatlogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chatlog>>> GetChatlog()
        {
            return await _context.Chatlog.ToListAsync();
        }

        // GET: api/Chatlogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chatlog>> GetChatlog(int id)
        {
            var chatlog = await _context.Chatlog.FindAsync(id);

            if (chatlog == null)
            {
                return NotFound();
            }

            return chatlog;
        }

        // PUT: api/Chatlogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatlog(int id, Chatlog chatlog)
        {
            if (id != chatlog.Chatlogid)
            {
                return BadRequest();
            }

            _context.Entry(chatlog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatlogExists(id))
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

        // POST: api/Chatlogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Chatlog>> PostChatlog(Chatlog chatlog)
        {
            _context.Chatlog.Add(chatlog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChatlogExists(chatlog.Chatlogid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChatlog", new { id = chatlog.Chatlogid }, chatlog);
        }

        // DELETE: api/Chatlogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chatlog>> DeleteChatlog(int id)
        {
            var chatlog = await _context.Chatlog.FindAsync(id);
            if (chatlog == null)
            {
                return NotFound();
            }

            _context.Chatlog.Remove(chatlog);
            await _context.SaveChangesAsync();

            return chatlog;
        }

        private bool ChatlogExists(int id)
        {
            return _context.Chatlog.Any(e => e.Chatlogid == id);
        }
    }
}
