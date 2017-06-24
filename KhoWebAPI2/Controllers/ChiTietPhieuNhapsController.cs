using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using KhoWebAPI2.Models;

namespace KhoWebAPI2.Controllers
{
    public class ChiTietPhieuNhapsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ChiTietPhieuNhaps
        public IQueryable<ChiTietPhieuNhap> GetChiTietPhieuNhaps()
        {
            return db.ChiTietPhieuNhaps;
        }

        // GET: api/ChiTietPhieuNhaps/5
        [ResponseType(typeof(ChiTietPhieuNhap))]
        public async Task<IHttpActionResult> GetChiTietPhieuNhap(int id)
        {
            ChiTietPhieuNhap chiTietPhieuNhap = await db.ChiTietPhieuNhaps.FindAsync(id);
            if (chiTietPhieuNhap == null)
            {
                return NotFound();
            }

            return Ok(chiTietPhieuNhap);
        }

        // PUT: api/ChiTietPhieuNhaps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChiTietPhieuNhap(int id, ChiTietPhieuNhap chiTietPhieuNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chiTietPhieuNhap.Id)
            {
                return BadRequest();
            }

            db.Entry(chiTietPhieuNhap).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietPhieuNhapExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ChiTietPhieuNhaps
        [ResponseType(typeof(ChiTietPhieuNhap))]
        public async Task<IHttpActionResult> PostChiTietPhieuNhap(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChiTietPhieuNhaps.Add(chiTietPhieuNhap);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = chiTietPhieuNhap.Id }, chiTietPhieuNhap);
        }

        // DELETE: api/ChiTietPhieuNhaps/5
        [ResponseType(typeof(ChiTietPhieuNhap))]
        public async Task<IHttpActionResult> DeleteChiTietPhieuNhap(int id)
        {
            ChiTietPhieuNhap chiTietPhieuNhap = await db.ChiTietPhieuNhaps.FindAsync(id);
            if (chiTietPhieuNhap == null)
            {
                return NotFound();
            }

            db.ChiTietPhieuNhaps.Remove(chiTietPhieuNhap);
            await db.SaveChangesAsync();

            return Ok(chiTietPhieuNhap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChiTietPhieuNhapExists(int id)
        {
            return db.ChiTietPhieuNhaps.Count(e => e.Id == id) > 0;
        }
    }
}