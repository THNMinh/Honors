using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VietKoiShow.Models;

namespace VietKoiShow.Controllers
{

    ////dong nay duoc chinh sua luc 4:40 - 10/15/2024
    [Route("api/[controller]")]
    [ApiController]
    public class TblkoiFishController : ControllerBase
    {
        private readonly VietKoiExpoContext _context;

        public TblkoiFishController(VietKoiExpoContext context)
        {
            _context = context;
        }

        // GET: api/TblkoiFish
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblkoiFish>>> GetTblkoiFishes()
        {
            return await _context.TblkoiFishes.ToListAsync();
        }

        // GET: api/TblkoiFish/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblkoiFish>> GetTblkoiFish(string id)
        {
            var tblkoiFish = await _context.TblkoiFishes.FindAsync(id);

            if (tblkoiFish == null)
            {
                return NotFound();
            }

            return tblkoiFish;
        }

        // PUT: api/TblkoiFish/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblkoiFish(string id, TblkoiFish tblkoiFish)
        {
            if (id != tblkoiFish.KoiId)
            {
                return BadRequest();
            }

            _context.Entry(tblkoiFish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblkoiFishExists(id))
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

        // POST: api/TblkoiFish
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblkoiFish>> PostTblkoiFish(TblkoiFish tblkoiFish)
        {
            _context.TblkoiFishes.Add(tblkoiFish);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblkoiFishExists(tblkoiFish.KoiId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblkoiFish", new { id = tblkoiFish.KoiId }, tblkoiFish);
        }

        // DELETE: api/TblkoiFish/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblkoiFish(string id)
        {
            var tblkoiFish = await _context.TblkoiFishes.FindAsync(id);
            if (tblkoiFish == null)
            {
                return NotFound();
            }

            _context.TblkoiFishes.Remove(tblkoiFish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblkoiFishExists(string id)
        {
            return _context.TblkoiFishes.Any(e => e.KoiId == id);
        }
    }
}
