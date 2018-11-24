using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace midterm.Models
{
    public class KetQua
    {
        [Display(Name = "Mã KQ")]
        [Key]
        public int MaKQ { get; set; }
        [Display(Name = "Mã môn")]
        [ForeignKey("MaMon")]
        public int MaMon { get; set; }
        [Display(Name = "Mã Sinh Viên")]
        [ForeignKey("MaSV")]
        public int MaSV { get; set; }
        [Display(Name = "Điểm")]
        public double Diem { get; set; }
    }
}
