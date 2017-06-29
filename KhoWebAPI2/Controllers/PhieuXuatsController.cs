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
   // [RoutePrefix("PhieuXuat")]
    public class PhieuXuatsController : ApiController
    {   
        
        //  private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWord unitOfWork = new UnitOfWord();

      //  [Route("")]
        // GET: api/PhieuXuats
        public IEnumerable<PhieuXuatDTO> GetPhieuXuats()
        {
            var phieuxuat = from a in unitOfWork.PhieuXuatRepository.Get()
                            select new PhieuXuatDTO
                            {
                                Id = a.Id,
                                NhanVienId = a.NhanVienId,
                                TongTien = a.TongTien
                            };
            return phieuxuat ;
        }
       // [Route("PhieuXuat/{id:int}")]
        // GET: api/PhieuXuats/5
        [ResponseType(typeof(PhieuXuatDTO))]
        public IHttpActionResult GetPhieuXuat(int id)
        {
            var phieuXuat = unitOfWork.PhieuXuatRepository.Get(includeProperties: "ChiTietPhieuXuats");

            return Ok(phieuXuat);
        }
        [Route("api/PhieuXuats/{id:int}/chiTietPhieuXuat")]
        [ResponseType(typeof(PhieuXuat))]
        public IHttpActionResult GetChiTietPhieuXuat(int id)
        {
            ChiTietPhieuXuat chiTietPhieuXuat = unitOfWork.ChiTietPhieuXuatRepository.GetByID(id);
            if (chiTietPhieuXuat == null)
            {
                return NotFound();
            }

            return Ok(chiTietPhieuXuat);
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
                unitOfWork.Save();
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

        private bool PhieuXuatExists(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/PhieuNhaps
        [ResponseType(typeof(PhieuXuat))]
        public IHttpActionResult PostPhieuXuat(PhieuXuat phieuXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.PhieuXuatRepository.Insert(phieuXuat);
            unitOfWork.Save();
            var phieuXuatDto = new PhieuXuatDTO
            {
                 NhanVienId=phieuXuat.NhanVienId,
                TongTien = phieuXuat.TongTien
                  
            };

            return CreatedAtRoute("DefaultApi", new { id = phieuXuat.Id }, phieuXuatDto);
        }

        // DELETE: api/PhieuNhaps/5
        [ResponseType(typeof(PhieuNhap))]
        public IHttpActionResult DeletePhieuNhap(int id)
        {
            PhieuXuat phieuXuat = unitOfWork.PhieuXuatRepository.GetByID(id);
            if (phieuXuat == null)
            {
                return NotFound();
            }

            unitOfWork.PhieuXuatRepository.Delete(phieuXuat);
            unitOfWork.Save();

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

        private bool PhieuNhapExists(int id)
        {
            return true;
        }
    }
}