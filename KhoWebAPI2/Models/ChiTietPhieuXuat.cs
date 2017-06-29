using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KhoWebAPI2.Models
{
    public class ChiTietPhieuXuat:Entity<int>
    {
     //  [Key]
        //public int Id { get; set; }
        public int SanPhamId { get; set; }
        public  SanPham SanPham { get; set; }
        public int PhieuXuatId { get; set; }
       public  PhieuXuat PhieuXuat { get; set; }
        public double giaTien { get; set; }
      
    }
}