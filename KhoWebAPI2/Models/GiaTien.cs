using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KhoWebAPI2.Models
{
    public class GiaTien:Entity<int>
    {
       // [Key]
       // public int Id { get; set; }
        [Required]
        public int SanPhamId { get; set; }
       // public virtual SanPham SanPham { get; set; }
        public DateTime NgayCapNhap { get; set; }
        public double giaTien;
    }
}