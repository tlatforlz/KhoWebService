using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace KhoWebAPI2.Models
{
    public class PhieuXuat:Entity<int>
    {
//[Key]
      //  public int Id { get; set; }
        public DateTime? NgayXuat { get; set; }
        public double TongTien { get; set; }
        public int NhanVienId { get; set; }
        public NhanVien NhanVien { get; set; }
        public ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
    }
}