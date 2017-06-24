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
    public class ChiTietPhieuXuatsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ChiTietPhieuXuats
        public IQueryable<ChiTietPhieuXuat> GetChiTietPhieuXuats()
        {
            return db.ChiTietPhieuXuats;
        }

        // GET: api/ChiTietPhieuXuats/5
        [ResponseType(typeof(ChiTietPhieuXuat))]
        public async Task<IHttpActionResult> GetChiTietPhieuXuat(int id)
        {
            ChiTietPhieuXuat chiTietPhieuXuat = await db.ChiTietPhieuXuats.FindAsync(id);
            if (chiTietPhieuXuat == null)
            {
                return NotFound();
            }

            return Ok(chiTietPhieuXuat);
        }

        // PUT: api/ChiTietPhieuXuats/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChiTietPhieuXuat(int id, ChiTietPhieuXuat chiTietPhieuXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chiTietPhieuXuat.Id)
            {
                return BadRequest();
            }

            db.Entry(chiTietPhieuXuat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietPhieuXuatExists(id))
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

        // POST: api/ChiTietPhieuXuats
        [ResponseType(typeof(ChiTietPhieuXuat))]
        public async Task<IHttpActionResult> PostChiTietPhieuXuat(ChiTietPhieuXuat chiTietPhieuXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChiTietPhieuXuats.Add(chiTietPhieuXuat);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = chiTietPhieuXuat.Id }, chiTietPhieuXuat);
        }

        // DELETE: api/ChiTietPhieuXuats/5
        [ResponseType(typeof(ChiTietPhieuXuat))]
        public async Task<IHttpActionResult> DeleteChiTietPhieuXuat(int id)
        {
            ChiTietPhieuXuat chiTietPhieuXuat = await db.ChiTietPhieuXuats.FindAsync(id);
            if (chiTietPhieuXuat == null)
            {
                return NotFound();
            }

            db.ChiTietPhieuXuats.Remove(chiTietPhieuXuat);
            await db.SaveChangesAsync();

            return Ok(chiTietPhieuXuat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChiTietPhieuXuatExists(int id)
        {
            return db.ChiTietPhieuXuats.Count(e => e.Id == id) > 0;
        }
    }
}