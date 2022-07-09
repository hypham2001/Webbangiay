using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webbansach.ViewModels
{
    public class ThuongHieuViewModel
    {
        public int MaThuonghieu { get; set; }

        [Required]
        [StringLength(50)]
        public string TenThuongHieu { get; set; }

        [StringLength(200)]
        public string Diachi { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }
    }
}