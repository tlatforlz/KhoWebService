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
    public class PhieuXuatsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PhieuXuats
        public IQueryable<PhieuXuat> GetPhieuXuats()
        {
            return db.PhieuXuats;
        }

        // GET: api/PhieuXuats/5
        [ResponseType(typeof(PhieuXuat))]
        public async Task<IHttpActionResult> GetPhieuXuat(int id)
        {
            PhieuXuat phieuXuat = await db.PhieuXuats.FindAsync(id);
            if (phieuXuat == null)
            {
                return NotFound();
            }

            return Ok(phieuXuat);
        }

        // PUT: api/PhieuXuats/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhieuXuat(int id, PhieuXuat phieuXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phieuXuat.Id)
            {
                return BadRequest();
            }

            db.Entry(phieuXuat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieuXuatExists(id))
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

        // POST: api/PhieuXuats
        [ResponseType(typeof(PhieuXuat))]
        public async Task<IHttpActionResult> PostPhieuXuat(PhieuXuat phieuXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhieuXuats.Add(phieuXuat);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = phieuXuat.Id }, phieuXuat);
        }

        // DELETE: api/PhieuXuats/5
        [ResponseType(typeof(PhieuXuat))]
        public async Task<IHttpActionResult> DeletePhieuXuat(int id)
        {
            PhieuXuat phieuXuat = await db.PhieuXuats.FindAsync(id);
            if (phieuXuat == null)
            {
                return NotFound();
            }

            db.PhieuXuats.Remove(phieuXuat);
            await db.SaveChangesAsync();

            return Ok(phieuXuat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhieuXuatExists(int id)
        {
            return db.PhieuXuats.Count(e => e.Id == id) > 0;
        }
    }
}