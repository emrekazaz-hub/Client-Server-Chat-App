using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesajController : ControllerBase
    {
        private readonly kayitgirisContext _context;

        public MesajController(kayitgirisContext context)
        {
            _context = context;
        }

        // GET: api/Mesaj
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mesaj>>> GetMesajs()
        {
            return await _context.Mesajs.ToListAsync();
        }

        // GET: api/Mesaj/5/1
        [HttpGet("{fromUser}/{toUser}")]
        public List<Mesaj> GetMesaj(int fromUser,int toUser)
        {
            var mesajlar = _context.Mesajs.Where(x=>x.FromUser==fromUser && x.ToUser == toUser).ToList();
            return mesajlar;
        }

        // PUT: api/Mesaj/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesaj(int id, Mesaj mesaj)
        {
            if (id != mesaj.Id)
            {
                return BadRequest();
            }

            _context.Entry(mesaj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesajExists(id))
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

        // POST: api/Mesaj
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mesaj>> PostMesaj(Mesaj mesaj)
        {
            _context.Mesajs.Add(mesaj);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MesajExists(mesaj.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMesaj", new { id = mesaj.Id }, mesaj);
        }

        // DELETE: api/Mesaj/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mesaj>> DeleteMesaj(int id)
        {
            var mesaj = await _context.Mesajs.FindAsync(id);
            if (mesaj == null)
            {
                return NotFound();
            }

            _context.Mesajs.Remove(mesaj);
            await _context.SaveChangesAsync();

            return mesaj;
        }

        private bool MesajExists(int id)
        {
            return _context.Mesajs.Any(e => e.Id == id);
        }
    }
}
