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
    public class SanPhamsController : ApiController
    {
        //  private ApplicationDbContext db = new ApplicationDbContext();

        private UnitOfWord unitOfWork = new UnitOfWord();
        // GET: api/SanPhams
        public IEnumerable<SanPhamDTO> GetSanPhams()
        {
            var sanPhamDto = from a in unitOfWork.SanPhamRepository.Get()
                             select new SanPhamDTO()
                             {  
                                 Id=a.Id,
                                 giaSanPham = a.giaSanPham,
                                 soLuongSanPham = a.soLuongSanPham,
                                 tenSanPham = a.tenSanPham
                             };
            return sanPhamDto;
        }

        // GET: api/SanPhams/5
        [ResponseType(typeof(SanPhamDTO))]
        public IHttpActionResult GetSanPham(int id)
        {
            var sanPham = unitOfWork.SanPhamRepository.GetByID(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            SanPhamDTO sanPhamDto = new SanPhamDTO
            {
                Id = sanPham.Id,
                tenSanPham = sanPham.tenSanPham,
                giaSanPham = sanPham.giaSanPham,
                soLuongSanPham = sanPham.soLuongSanPham
            };

            return Ok(sanPhamDto);
        }
        [Route("api/SanPhams/{id:int}/chiTiet")]
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult GetChiTietPhieuNhap(int id)
        {
            ChiTietPhieuNhap chiTietPhieuNhap = unitOfWork.ChiTietPhieuNhapRepository.GetByID(id);
            if (chiTietPhieuNhap == null)
            {
                return NotFound();
            }

            return Ok(chiTietPhieuNhap);
        }
        [Route("api/SanPhams/{id:int}/chiTietPhieuXuat")]
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult GetChiTietPhieuXuat(int id)
        {
            ChiTietPhieuXuat chiTietPhieuXuat = unitOfWork.ChiTietPhieuXuatRepository.GetByID(id);
            if (chiTietPhieuXuat == null)
            {
                return NotFound();
            }

            return Ok(chiTietPhieuXuat);
        }


        [Route("api/SanPhams/{id:int}/giaTien")]
        [ResponseType(typeof(GiaTienDTO))]
        public IHttpActionResult GetGiaTien(int id)
        {
            var giaSanPham = unitOfWork.SanPhamRepository.Get(x=>x.Id==id,null,"GiaTien");
            if (giaSanPham == null)
            {
                return NotFound();
            }
            GiaTien giaTien = new GiaTien
            {
                   
            }

            return Ok(giaSanPham);
        }
        //PUT GIA
        [Route("api/SanPhams/{id:int}/UpdateGiaTien")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGiaSanPham(int id, GiaTien giaTien)
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
            var giaSP = new GiaTienDTO
            {
                SanPhamId = giaTien.SanPhamId,
                giaTien = giaTien.giaTien
            };

            try
            {
                unitOfWork.Save();
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

            return CreatedAtRoute("DefaultApi", new { id = giaTien.Id }, giaSP);
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
                unitOfWork.Save();
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

            sanPham.GiaTiens = new List<GiaTien>();
            sanPham.GiaTiens.Add(new GiaTien() { giaTien = sanPham.giaSanPham, NgayCapNhap = DateTime.UtcNow });
            unitOfWork.SanPhamRepository.Insert(sanPham);
            unitOfWork.Save();
            var SanPhamDto = new SanPhamDTO
            {
                tenSanPham = sanPham.tenSanPham,
                soLuongSanPham = sanPham.soLuongSanPham,
                giaSanPham = sanPham.giaSanPham

            };
            return CreatedAtRoute("DefaultApi", new { id = sanPham.Id }, SanPhamDto);
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
            unitOfWork.Save();
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