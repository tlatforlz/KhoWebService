using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhoWebAPI2.Models;

namespace KhoWebAPI2.DTO
{
    public class PhieuXuatDTO:AuditableEntity< int>
    {

       public DateTime NgayXuat { get; set; }
        public double TongTien { get; set; }
        public int NhanVienId { get; set; }
        public string Nhanvien { get; set; }
    }
}
