using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KhoWebAPI2.Models
{
    public class PhieuNhap
    {
        [Key]
        public int Id { get; set; }
        public DateTime ngayNhap { get; set; }
        public int tongTien { get; set; }

        public int NhanVienId { get; set; }
        public NhanVien NhanVien { get; set; }

    }
}