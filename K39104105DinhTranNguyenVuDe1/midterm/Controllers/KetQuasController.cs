using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using midterm.Models;

namespace midterm.Controllers
{
    [Produces("application/json")]
    [Route("api/KetQuas")]
    public class KetQuasController : Controller
    {
        private readonly MyDBContext _context;

        public KetQuasController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/KetQuas
        [HttpGet]
        public IEnumerable<KetQua> GetKetQuas()
        {
            return _context.KetQuas;
        }

        // GET: api/KetQuas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKetQua([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ketQua = await _context.KetQuas.SingleOrDefaultAsync(m => m.MaKQ == id);

            if (ketQua == null)
            {
                return NotFound();
            }

            return Ok(ketQua);
        }

        // PUT: api/KetQuas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKetQua([FromRoute] int id, [FromBody] KetQua ketQua)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ketQua.MaKQ)
            {
                return BadRequest();
            }

            _context.Entry(ketQua).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KetQuaExists(id))
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

        // POST: api/KetQuas
        [HttpPost]
        public async Task<IActionResult> PostKetQua([FromBody] KetQua ketQua)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.KetQuas.Add(ketQua);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKetQua", new { id = ketQua.MaKQ }, ketQua);
        }

        // DELETE: api/KetQuas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKetQua([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ketQua = await _context.KetQuas.SingleOrDefaultAsync(m => m.MaKQ == id);
            if (ketQua == null)
            {
                return NotFound();
            }

            _context.KetQuas.Remove(ketQua);
            await _context.SaveChangesAsync();

            return Ok(ketQua);
        }

        private bool KetQuaExists(int id)
        {
            return _context.KetQuas.Any(e => e.MaKQ == id);
        }
    }
}