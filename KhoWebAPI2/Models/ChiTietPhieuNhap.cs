using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KhoWebAPI2.Models
{
    public class ChiTietPhieuNhap
    {
        [Key]
        public int Id { get; set; }
        public int SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
        public int PhieuNhapId { get; set; }
        public PhieuNhap PhieuNhap { get; set; }
        public int giaTien { get; set; }
    }
}