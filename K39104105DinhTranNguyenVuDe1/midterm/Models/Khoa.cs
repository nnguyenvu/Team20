using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace midterm.Models
{
    public class Khoa
    {
        [Display(Name = "Mã Khoa")]
        [Key]
        public int MaKhoa { get; set; }
        [Display(Name = "Tên Khoa")]
        public string TenKhoa { get; set; }
        
        
    }
}
