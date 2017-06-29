using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhoWebAPI2.DTO;
using KhoWebAPI2.Models;

namespace KhoWebAPI2.DAL
{
    public class UnitOfWord: IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private GenericRepository<PhieuXuat> phieuXuatRepository;
        private GenericRepository<SanPham> sanPhamRepository;
        private GenericRepository<NhanVien> nhanVienRepository;
        private GenericRepository<GiaTien> giaTienRepository;
        private GenericRepository<PhieuNhap> phieuNhapRepository;
        private GenericRepository<ChiTietPhieuNhap> chiTietPhieuNhapRepository;
        private GenericRepository<ChiTietPhieuXuat> chiTietPhieuXuatRepository;
        private GenericRepository<PhieuXuatDTO> phieuXuatDtoRepository;

        public GenericRepository<PhieuXuat> PhieuXuatRepository
        {
            get
            {

                if (this.phieuXuatRepository == null)
                {
                    this.phieuXuatRepository = new GenericRepository<PhieuXuat>(db);
                }
                return phieuXuatRepository;
            }
        }

        public GenericRepository<SanPham> SanPhamRepository
        {
            get
            {

                if (this.sanPhamRepository == null)
                {
                    this.sanPhamRepository = new GenericRepository<SanPham>(db);
                }
                return sanPhamRepository;
            }
        }
        public GenericRepository<NhanVien> NhanVienRepository
        {
            get
            {

                if (this.nhanVienRepository == null)
                {
                    this.nhanVienRepository = new GenericRepository<NhanVien>(db);
                }
                return nhanVienRepository;
            }
        }
        public GenericRepository<GiaTien> GiaTienRepository
        {
            get
            {

                if (this.giaTienRepository == null)
                {
                    this.giaTienRepository = new GenericRepository<GiaTien>(db);
                }
                return giaTienRepository;
            }
        }
        public GenericRepository<PhieuNhap> PhieuNhapRepository
        {
            get
            {

                if (this.phieuNhapRepository == null)
                {
                    this.phieuNhapRepository = new GenericRepository<PhieuNhap>(db);
                }
                return phieuNhapRepository;
            }
        }
        public GenericRepository<ChiTietPhieuNhap> ChiTietPhieuNhapRepository
        {
            get
            {

                if (this.chiTietPhieuNhapRepository == null)
                {
                    this.chiTietPhieuNhapRepository = new GenericRepository<ChiTietPhieuNhap>(db);
                }
                return chiTietPhieuNhapRepository;
            }
        }

        public GenericRepository<ChiTietPhieuXuat> ChiTietPhieuXuatRepository
        {
            get
            {

                if (this.chiTietPhieuXuatRepository == null)
                {
                    this.chiTietPhieuXuatRepository = new GenericRepository<ChiTietPhieuXuat>(db);
                }
                return chiTietPhieuXuatRepository;
            }
        }
        public GenericRepository<PhieuXuatDTO> PhieuXuatDTORepository
        {
            get
            {

                if (this.phieuXuatDtoRepository == null)
                {
                    this.phieuXuatDtoRepository = new GenericRepository<PhieuXuatDTO>(db);
                }
                return phieuXuatDtoRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                } 
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool BookExists(int id)
        {
            return true;
        }
    }
}