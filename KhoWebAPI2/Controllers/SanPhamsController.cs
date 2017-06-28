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
    public class SanPhamsController : ApiController
    {
        //  private ApplicationDbContext db = new ApplicationDbContext();

        private UnitOfWord unitOfWork = new UnitOfWord();
        // GET: api/SanPhams
        public IEnumerable<SanPham> GetSanPhams()
        {
            return unitOfWork.SanPhamRepository.Get();
        }

        // GET: api/SanPhams/5
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult GetSanPham(int id)
        {
            SanPham sanPham = unitOfWork.SanPhamRepository.GetByID(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return Ok(sanPham);
        }

        // PUT: api/SanPhams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSanPham(int id, SanPham sanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanPham.Id)
            {
                return BadRequest();
            }

            unitOfWork.SanPhamRepository.Update(sanPham);

            try
            {
                unitOfWork.SanPhamRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(id))
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

        // POST: api/SanPhams
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult PostSanPham(SanPham sanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.SanPhamRepository.Insert(sanPham);
            unitOfWork.SanPhamRepository.Save();

            return CreatedAtRoute("DefaultApi", new { id = sanPham.Id }, sanPham);
        }

        // DELETE: api/SanPhams/5
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult DeleteSanPham(int id)
        {
            SanPham sanPham = unitOfWork.SanPhamRepository.GetByID(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            unitOfWork.SanPhamRepository.Delete(sanPham);
            unitOfWork.SanPhamRepository.Save();

            return Ok(sanPham);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.SanPhamRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SanPhamExists(int id)
        {
            return true;
        }
    }
}