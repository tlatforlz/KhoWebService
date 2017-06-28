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
    public class ChiTietPhieuXuatsController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWord unitOfWork = new UnitOfWord();
        // GET: api/ChiTietPhieuXuats
        public IEnumerable<ChiTietPhieuXuat> GetChiTietPhieuXuats()
        {
            return unitOfWork.ChiTietPhieuXuatRepository.Get();
        }

        // GET: api/ChiTietPhieuXuats/5
        [ResponseType(typeof(ChiTietPhieuXuat))]
        public IHttpActionResult GetChiTietPhieuXuat(int id)
        {
            ChiTietPhieuXuat chiTietPhieuXuat = unitOfWork.ChiTietPhieuXuatRepository.GetByID(id);
            if (chiTietPhieuXuat == null)
            {
                return NotFound();
            }

            return Ok(chiTietPhieuXuat);
        }

        // PUT: api/ChiTietPhieuXuats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChiTietPhieuXuat(int id, ChiTietPhieuXuat chiTietPhieuXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chiTietPhieuXuat.Id)
            {
                return BadRequest();
            }

            unitOfWork.ChiTietPhieuXuatRepository.Update(chiTietPhieuXuat);

            try
            {
                unitOfWork.ChiTietPhieuXuatRepository.Save();
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
        public IHttpActionResult PostChiTietPhieuXuat(ChiTietPhieuXuat chiTietPhieuXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.ChiTietPhieuXuatRepository.Insert(chiTietPhieuXuat);
            unitOfWork.ChiTietPhieuXuatRepository.Save();

            return CreatedAtRoute("DefaultApi", new { id = chiTietPhieuXuat.Id }, chiTietPhieuXuat);
        }

        // DELETE: api/ChiTietPhieuXuats/5
        [ResponseType(typeof(ChiTietPhieuXuat))]
        public async Task<IHttpActionResult> DeleteChiTietPhieuXuat(int id)
        {
            ChiTietPhieuXuat chiTietPhieuXuat = unitOfWork.ChiTietPhieuXuatRepository.GetByID(id);
            if (chiTietPhieuXuat == null)
            {
                return NotFound();
            }

            unitOfWork.ChiTietPhieuXuatRepository.Delete(chiTietPhieuXuat);
            unitOfWork.ChiTietPhieuXuatRepository.Save();

            return Ok(chiTietPhieuXuat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.ChiTietPhieuXuatRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChiTietPhieuXuatExists(int id)
        {
            return true;
        }
    }
}