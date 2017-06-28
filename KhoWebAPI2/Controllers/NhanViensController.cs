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
    public class NhanViensController : ApiController
    {
        // private ApplicationDbContext db = new ApplicationDbContext();

        private UnitOfWord unitOfWork = new UnitOfWord();

        // GET: api/PhieuXuats
        public IEnumerable<NhanVien> GetNhanViens()
        {
            return unitOfWork.NhanVienRepository.Get();
        }

        // GET: api/NhanViens/5
        [ResponseType(typeof(NhanVien))]
        public IHttpActionResult GetNhanVien(int id)
        {
            NhanVien nhanVien = unitOfWork.NhanVienRepository.GetByID(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return Ok(nhanVien);
        }

        // PUT: api/NhanViens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhanVien(int id, NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhanVien.Id)
            {
                return BadRequest();
            }

            unitOfWork.NhanVienRepository.Update(nhanVien);

            try
            {
                unitOfWork.NhanVienRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVienExists(id))
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

        // POST: api/NhanViens
        [ResponseType(typeof(NhanVien))]
        public IHttpActionResult PostNhanVien(NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.NhanVienRepository.Insert(nhanVien);
            unitOfWork.NhanVienRepository.Save();

            return CreatedAtRoute("DefaultApi", new { id = nhanVien.Id }, nhanVien);
        }

        // DELETE: api/NhanViens/5
        [ResponseType(typeof(NhanVien))]
        public IHttpActionResult DeleteNhanVien(int id)
        {
            NhanVien nhanVien = unitOfWork.NhanVienRepository.GetByID(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            unitOfWork.NhanVienRepository.Delete(nhanVien);
            unitOfWork.NhanVienRepository.Save();

            return Ok(nhanVien);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.NhanVienRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhanVienExists(int id)
        {
            return true;
        }
    }
}