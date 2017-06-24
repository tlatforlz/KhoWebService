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
    public class PhieuNhapsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PhieuNhaps
        public IQueryable<PhieuNhap> GetPhieuNhaps()
        {
            return db.PhieuNhaps;
        }

        // GET: api/PhieuNhaps/5
        [ResponseType(typeof(PhieuNhap))]
        public async Task<IHttpActionResult> GetPhieuNhap(int id)
        {
            PhieuNhap phieuNhap = await db.PhieuNhaps.FindAsync(id);
            if (phieuNhap == null)
            {
                return NotFound();
            }

            return Ok(phieuNhap);
        }

        // PUT: api/PhieuNhaps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhieuNhap(int id, PhieuNhap phieuNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phieuNhap.Id)
            {
                return BadRequest();
            }

            db.Entry(phieuNhap).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieuNhapExists(id))
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

        // POST: api/PhieuNhaps
        [ResponseType(typeof(PhieuNhap))]
        public async Task<IHttpActionResult> PostPhieuNhap(PhieuNhap phieuNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhieuNhaps.Add(phieuNhap);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = phieuNhap.Id }, phieuNhap);
        }

        // DELETE: api/PhieuNhaps/5
        [ResponseType(typeof(PhieuNhap))]
        public async Task<IHttpActionResult> DeletePhieuNhap(int id)
        {
            PhieuNhap phieuNhap = await db.PhieuNhaps.FindAsync(id);
            if (phieuNhap == null)
            {
                return NotFound();
            }

            db.PhieuNhaps.Remove(phieuNhap);
            await db.SaveChangesAsync();

            return Ok(phieuNhap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhieuNhapExists(int id)
        {
            return db.PhieuNhaps.Count(e => e.Id == id) > 0;
        }
    }
}