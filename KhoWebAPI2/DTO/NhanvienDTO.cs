using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhoWebAPI2.Models;

namespace KhoWebAPI2.DTO
{
    public class NhanvienDTO: Entity<int>
    {
        public String hoNhanVien { get; set; }
        public String tenNhanVien { get; set; }
        public DateTime ngayThamGia { get; set; }
        public String diaChi { get; set; }
        public String soDienThoai { get; set; }
        public String email { get; set; }
        public String Capbac { get; set; }
    }
}