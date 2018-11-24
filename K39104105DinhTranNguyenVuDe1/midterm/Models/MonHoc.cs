using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace midterm.Models
{
    public class MonHoc
    {
        [Display(Name = "Mã Môn")]
        [Key]
        public int MaMon { get; set; }
        [Display(Name = "Tên Môn")]
        public string TenMon { get; set; }
        [Display(Name = "Số tín chỉ")]
        public int SoTinChi { get; set; }
        
    }
}
