using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhoWebAPI2.DTO
{
    public class SanPhamDTO
    {
        public int Id { get; set; }
        public String tenSanPham { get; set; }
        public double giaSanPham { get; set; }
        public int soLuongSanPham { get; set; }

    }
}