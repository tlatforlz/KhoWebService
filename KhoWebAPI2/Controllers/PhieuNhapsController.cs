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
using KhoWebAPI2.Models;

namespace KhoWebAPI2.Controllers
{
    public class PhieuNhapsController : ApiController
    {
        //  private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWord unitOfWork = new UnitOfWord();
        // GET: api/PhieuNhaps
        public IEnumerable<PhieuNhap> GetPhieuNhaps()
        {
            return unitOfWork.PhieuNhapRepository.Get();
        }

        // GET: api/PhieuNhaps/5
        [ResponseType(typeof(PhieuNhap))]
        public IHttpActionResult GetPhieuNhap(int id)
        {
            PhieuNhap phieuNhap = unitOfWork.PhieuNhapRepository.GetByID(id);
            if (phieuNhap == null)
            {
                return NotFound();
            }

            return Ok(phieuNhap);
        }
        [Route("api/PhieuNhaps/{id:int}/chiTietPhieuNhap")]
        [ResponseType(typeof(PhieuNhap))]
        public IHttpActionResult GetChiTietPhieuXuat(int id)
        {
            ChiTietPhieuNhap chiTietPhieuNhap = unitOfWork.ChiTietPhieuNhapRepository.GetByID(id);
            if (chiTietPhieuNhap == null)
            {
                return NotFound();
            }

            return Ok(chiTietPhieuNhap);
        }
        // PUT: api/PhieuNhaps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhieuNhap(int id, PhieuNhap phieuNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phieuNhap.Id)
            {
                return BadRequest();
            }

            unitOfWork.PhieuNhapRepository.Update(phieuNhap);

            try
            {
                unitOfWork.Save();
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
        public IHttpActionResult PostPhieuNhap(PhieuNhap phieuNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.PhieuNhapRepository.Insert(phieuNhap);
            unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = phieuNhap.Id }, phieuNhap);
        }

        // DELETE: api/PhieuNhaps/5
        [ResponseType(typeof(PhieuNhap))]
        public IHttpActionResult DeletePhieuNhap(int id)
        {
            PhieuNhap phieuNhap = unitOfWork.PhieuNhapRepository.GetByID(id);
            if (phieuNhap == null)
            {
                return NotFound();
            }

            unitOfWork.PhieuNhapRepository.Delete(phieuNhap);
            unitOfWork.Save();

            return Ok(phieuNhap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.PhieuNhapRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhieuNhapExists(int id)
        {
            return true;
        }
    }
}