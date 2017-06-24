using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KhoWebAPI2.Models
{
    public class SanPham
    {
        [Key]
        public int Id { get; set; }
        public String tenSanPham { get; set; }
        public int giaSanPham { get; set; }
        public int soLuongSanPham { get; set; }

    }
}