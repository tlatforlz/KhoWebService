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
using KhoWebAPI2.DAL;
using KhoWebAPI2.DTO;
using KhoWebAPI2.Models;

namespace KhoWebAPI2.Controllers
{

    public class GiaTiensController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWord unitOfWork = new UnitOfWord();
        // GET: api/GiaTiens
        public IEnumerable<GiaTienDTO> GetGiaTiens()
        {
            var giatien = from a in unitOfWork.GiaTienRepository.Get()
                            select new GiaTienDTO
                            {
                                 SanPhamId=a.SanPhamId,
                                  giaTien= a.giaTien
                            };
            return giatien;
        }
        // GET: api/GiaTiens/5
        [ResponseType(typeof(GiaTien))]
        public IHttpActionResult GetGiaTien(int id)
        {
            GiaTien giaTien = unitOfWork.GiaTienRepository.GetByID(id);
            if (giaTien == null)
            {
                return NotFound();
            }

            return Ok(giaTien);
        }

        // PUT: api/GiaTiens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGiaTien(int id, GiaTien giaTien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != giaTien.Id)
            {
                return BadRequest();
            }

            unitOfWork.GiaTienRepository.Update(giaTien);

            try
            {
                unitOfWork.Save();
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
        public IHttpActionResult PostGiaTien(GiaTien giaTien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.GiaTienRepository.Insert(giaTien);
            unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = giaTien.Id }, giaTien);
        }

        // DELETE: api/GiaTiens/5
        [ResponseType(typeof(GiaTien))]
        public IHttpActionResult DeleteGiaTien(int id)
        {
            GiaTien giaTien = unitOfWork.GiaTienRepository.GetByID(id);
            if (giaTien == null)
            {
                return NotFound();
            }

            unitOfWork.GiaTienRepository.Delete(giaTien);
            unitOfWork.Save();

            return Ok(giaTien);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.GiaTienRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GiaTienExists(int id)
        {
            return true;
        }
    }
}