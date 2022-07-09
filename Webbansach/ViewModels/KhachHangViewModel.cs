using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webbansach.ViewModels
{
    public class KhachHangViewModel
    {
        public int MaKH { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string Taikhoan { get; set; }

        [Required]
        [StringLength(50)]
        public string Matkhau { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string DiachiKH { get; set; }

        [StringLength(50)]
        public string DienthoaiKH { get; set; }

        public DateTime Ngaysinh { get; set; }

        public bool TinhTrang { get; set; }
    }
}