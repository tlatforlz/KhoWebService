using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KhoWebAPI2.Models
{
    public class NhanVien:Entity<int>
    {
      //  [Key]
       // public int Id { get; set; }
        [Required]
        public String hoNhanVien { get; set; }
        [Required]
        public String tenNhanVien { get; set; }
        public DateTime ngayThamGia { get; set; }
        public String diaChi { get; set; }
        public String soDienThoai { get; set; }
        public String email { get; set; }
        public String Capbac { get; set; }

    }
}