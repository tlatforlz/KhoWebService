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
    public class PhieuXuatsController : ApiController
    {
       // private ApplicationDbContext db = new ApplicationDbContext();
       private UnitOfWord unitOfWork = new UnitOfWord();
        
        // GET: api/PhieuXuats
        public IEnumerable<PhieuXuat> GetPhieuXuats()
        {
            return unitOfWork.PhieuXuatRepository.Get();      
        }

        // GET: api/PhieuXuats/5
        [ResponseType(typeof(PhieuXuat))]
        public IHttpActionResult GetPhieuXuat(int id)
        {
            PhieuXuat phieuXuat = unitOfWork.PhieuXuatRepository.GetByID(id);
            if (phieuXuat == null)
            {
                return NotFound();
            }

            return Ok(phieuXuat);
        }

        // PUT: api/PhieuXuats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhieuXuat(int id, PhieuXuat phieuXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phieuXuat.Id)
            {
                return BadRequest();
            }

            unitOfWork.PhieuXuatRepository.Update(phieuXuat);

            try
            {
                unitOfWork.PhieuXuatRepository.Save();
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
        public IHttpActionResult PostPhieuXuat(PhieuXuat phieuXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.PhieuXuatRepository.Insert(phieuXuat);
            unitOfWork.PhieuXuatRepository.Save();

            return CreatedAtRoute("DefaultApi", new { id = phieuXuat.Id }, phieuXuat);
        }

        // DELETE: api/PhieuXuats/5
        [ResponseType(typeof(PhieuXuat))]
        public IHttpActionResult DeletePhieuXuat(int id)
        {
            PhieuXuat phieuXuat = unitOfWork.PhieuXuatRepository.GetByID(id);
            if (phieuXuat == null)
            {
                return NotFound();
            }

            unitOfWork.PhieuXuatRepository.Delete(phieuXuat);
            unitOfWork.PhieuXuatRepository.Save();

            return Ok(phieuXuat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.PhieuXuatRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhieuXuatExists(int id)
        {
            return true;
        }
    }

}