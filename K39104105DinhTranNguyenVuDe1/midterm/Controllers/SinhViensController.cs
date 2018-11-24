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
    [Route("api/SinhViens")]
    public class SinhViensController : Controller
    {
        private readonly MyDBContext _context;

        public SinhViensController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/SinhViens
        [HttpGet]
        public IEnumerable<SinhVien> GetSinhViens()
        {
            return _context.SinhViens;
        }

        //GET: api/SinhViens
       //[HttpGet]
       //public IEnumerable<SinhVien> GetSinhViens()
       //{
       //    return View();
       //}

       // GET: api/SinhViens/5
       [HttpGet("{id}")]
        public async Task<IActionResult> GetSinhVien([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sinhVien = await _context.SinhViens.SingleOrDefaultAsync(m => m.MaSV == id);

            if (sinhVien == null)
            {
                return NotFound();
            }

            return Ok(sinhVien);
        }

        // PUT: api/SinhViens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinhVien([FromRoute] int id, [FromBody] SinhVien sinhVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sinhVien.MaSV)
            {
                return BadRequest();
            }

            _context.Entry(sinhVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinhVienExists(id))
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

        // POST: api/SinhViens
        [HttpPost]
        public async Task<IActionResult> PostSinhVien([FromBody] SinhVien sinhVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SinhViens.Add(sinhVien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSinhVien", new { id = sinhVien.MaSV }, sinhVien);
        }

        // DELETE: api/SinhViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinhVien([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sinhVien = await _context.SinhViens.SingleOrDefaultAsync(m => m.MaSV == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            _context.SinhViens.Remove(sinhVien);
            await _context.SaveChangesAsync();

            return Ok(sinhVien);
        }

        private bool SinhVienExists(int id)
        {
            return _context.SinhViens.Any(e => e.MaSV == id);
        }
    }
}