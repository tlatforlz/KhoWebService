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
    public class ChiTietPhieuNhapsController : ApiController
    {
        // private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWord unitOfWork = new UnitOfWord();
        // GET: api/ChiTietPhieuNhaps
        public IEnumerable<ChiTietPhieuNhap> GetChiTietPhieuNhaps()
        {
            return unitOfWork.ChiTietPhieuNhapRepository.Get();
        }

        // GET: api/ChiTietPhieuNhaps/5
        [ResponseType(typeof(ChiTietPhieuNhap))]
        public IHttpActionResult GetChiTietPhieuNhap(int id)
        {
            ChiTietPhieuNhap chiTietPhieuNhap = unitOfWork.ChiTietPhieuNhapRepository.GetByID(id);
            if (chiTietPhieuNhap == null)
            {
                return NotFound();
            }

            return Ok(chiTietPhieuNhap);
        }

        // PUT: api/ChiTietPhieuNhaps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChiTietPhieuNhap(int id, ChiTietPhieuNhap chiTietPhieuNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chiTietPhieuNhap.Id)
            {
                return BadRequest();
            }

            unitOfWork.ChiTietPhieuNhapRepository.Update(chiTietPhieuNhap);

            try
            {
                unitOfWork.Save();
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
        public IHttpActionResult PostChiTietPhieuNhap(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.ChiTietPhieuNhapRepository.Insert(chiTietPhieuNhap);
            unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = chiTietPhieuNhap.Id }, chiTietPhieuNhap);
        }

        // DELETE: api/ChiTietPhieuNhaps/5
        [ResponseType(typeof(ChiTietPhieuNhap))]
        public IHttpActionResult DeleteChiTietPhieuNhap(int id)
        {
            ChiTietPhieuNhap chiTietPhieuNhap = unitOfWork.ChiTietPhieuNhapRepository.GetByID(id);
            if (chiTietPhieuNhap == null)
            {
                return NotFound();
            }

            unitOfWork.ChiTietPhieuNhapRepository.Delete(chiTietPhieuNhap);
            unitOfWork.Save();

            return Ok(chiTietPhieuNhap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.ChiTietPhieuNhapRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChiTietPhieuNhapExists(int id)
        {
            return true;
        }
    }
}