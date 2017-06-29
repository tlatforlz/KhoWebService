namespace KhoWebAPI2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using KhoWebAPI2.Models;

    public class Configuration : DbMigrationsConfiguration<KhoWebAPI2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KhoWebAPI2.Models.ApplicationDbContext context)
        {
            var NhanViens = new List <NhanVien> {
                new NhanVien() {
                    Id =1, hoNhanVien="ABC", tenNhanVien="abc", Capbac="NV", diaChi="Q9", email="amc", ngayThamGia= DateTime.Parse("1986-2-23"), soDienThoai="121" },
                               new NhanVien()
                               {
                                   Id = 2,
                                   hoNhanVien = "ABC",
                                   tenNhanVien = "abc",
                                   Capbac = "NV",
                                   diaChi = "Q9",
                                   email = "amc",
                                   ngayThamGia = DateTime.Parse("1986-2-23"),
                                   soDienThoai = "121"
                               },
                                              new NhanVien()
                                              {
                                                  Id = 3,
                                                  hoNhanVien = "ABC",
                                                  tenNhanVien = "abc",
                                                  Capbac = "NV",
                                                  diaChi = "Q9",
                                                  email = "amc",
                                                  ngayThamGia = DateTime.Parse("1986-2-23"),
                                                  soDienThoai = "121"
                                              }

                };
            NhanViens.ForEach(s => context.NhanViens.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            var SanPhams = new List<SanPham> {
                new SanPham()
                {
                    Id = 1,
                    tenSanPham = "SD",
                    soLuongSanPham = 23,
                    giaSanPham = 23434
                },
                                new SanPham()
                                {
                                    Id = 2,
                                    tenSanPham = "SDscdd",
                                    soLuongSanPham = 23,
                                    giaSanPham = 23434
                                },
                                                new SanPham()
                                                {
                                                    Id = 3,
                                                    tenSanPham = "SD",
                                                    soLuongSanPham = 23,
                                                    giaSanPham = 23434
                                                }
            };
            SanPhams.ForEach(s => context.SanPhams.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
            var GiaTiens = new List<GiaTien>
            {
                new GiaTien()
                {
                    Id=1,
                    SanPhamId=1,
                     NgayCapNhap = DateTime.Parse("1986-2-23")
                }
            };
            GiaTiens.ForEach(s => context.GiaTiens.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
            var PhieuXuats = new List<PhieuXuat>
            {
                new PhieuXuat()
                {
                    Id = 1,
                     NgayXuat = DateTime.Parse("1986-2-23"),
                      NhanVienId=1,
                        TongTien =12234
                }
            };
            PhieuXuats.ForEach(s => context.PhieuXuats.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
            var PhieuNhaps = new List<PhieuNhap>
            {
                new PhieuNhap()
                {
                    Id = 1,
                     //ngayNhap = DateTime.Parse("1986-2-23"),
                      NhanVienId=1,
                        tongTien =345545
                }
            };
            PhieuNhaps.ForEach(s => context.PhieuNhaps.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            var ChiTietPhieuNhaps = new List<ChiTietPhieuNhap>
            {
                new ChiTietPhieuNhap()
                {
                    Id = 1,
                     SanPhamId=1,
                         PhieuNhapId=1,
                          giaTien=34354000
                }
            };
            ChiTietPhieuNhaps.ForEach(s => context.ChiTietPhieuNhaps.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
            var ChiTietPhieuXuats = new List<ChiTietPhieuXuat>
            {
                new ChiTietPhieuXuat()
                {
                    Id = 1,
                     SanPhamId=1,
                         PhieuXuatId=1,
                          giaTien=3777000
                }
            };
            ChiTietPhieuXuats.ForEach(s => context.ChiTietPhieuXuats.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
        }
    }
}
