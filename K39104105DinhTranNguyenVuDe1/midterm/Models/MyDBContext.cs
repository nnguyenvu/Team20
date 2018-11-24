using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace midterm.Models
{
    public class MyDBContext:DbContext
    {
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<KetQua> KetQuas { get; set; }
        public MyDBContext(DbContextOptions options) : base(options)//ham tao
        {
            //add vao ConfigureService = vao startup.cs/ 
        }
    }
}
