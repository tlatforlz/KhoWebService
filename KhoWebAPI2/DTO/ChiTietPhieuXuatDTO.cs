using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhoWebAPI2.Models;

namespace KhoWebAPI2.DTO
{
    public class ChiTietPhieuXuatDTO:AuditableEntity<int>
    {
        public int SanPhamId { get; set; }
        public SanPhamDTO SanPham { get; set; }
        public int PhieuXuatId { get; set; }
        public PhieuXuat PhieuXuat { get; set; }
        public double giaTien { get; set; }
    }
}