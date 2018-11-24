using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace midterm.Models
{
    public class SinhVien
    {
        
        [Display(Name = "Mã Sinh Viên")]
        [Key]
        public int MaSV { get; set; }
        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }
        [Display(Name = "Điện Thoại")]
        public int DienThoai { get; set; }
       
    }
}
