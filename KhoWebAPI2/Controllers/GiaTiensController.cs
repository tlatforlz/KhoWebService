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
    public class GiaTiensController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/GiaTiens
        public IQueryable<GiaTien> GetGiaTiens()
        {
            return db.GiaTiens;
        }

        // GET: api/GiaTiens/5
        [ResponseType(typeof(GiaTien))]
        public async Task<IHttpActionResult> GetGiaTien(int id)
        {
            GiaTien giaTien = await db.GiaTiens.FindAsync(id);
            if (giaTien == null)
            {
                return NotFound();
            }

            return Ok(giaTien);
        }

        // PUT: api/GiaTiens/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGiaTien(int id, GiaTien giaTien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != giaTien.Id)
            {
                return BadRequest();
            }

            db.Entry(giaTien).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaTienExists(id))
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

        // POST: api/GiaTiens
        [ResponseType(typeof(GiaTien))]
        public async Task<IHttpActionResult> PostGiaTien(GiaTien giaTien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GiaTiens.Add(giaTien);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = giaTien.Id }, giaTien);
        }

        // DELETE: api/GiaTiens/5
        [ResponseType(typeof(GiaTien))]
        public async Task<IHttpActionResult> DeleteGiaTien(int id)
        {
            GiaTien giaTien = await db.GiaTiens.FindAsync(id);
            if (giaTien == null)
            {
                return NotFound();
            }

            db.GiaTiens.Remove(giaTien);
            await db.SaveChangesAsync();

            return Ok(giaTien);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GiaTienExists(int id)
        {
            return db.GiaTiens.Count(e => e.Id == id) > 0;
        }
    }
}