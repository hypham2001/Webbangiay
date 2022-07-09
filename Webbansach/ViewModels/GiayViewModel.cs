using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webbansach.ViewModels
{
    public class GiayViewModel
    {
        public int Magiay { get; set; }

        [Required]
        [StringLength(100)]
        public string Tengiay { get; set; }

        public decimal? Giaban { get; set; }

        public string Mota { get; set; }

        [StringLength(50)]
        public string Anhbia { get; set; }

        public DateTime? Ngaycapnhat { get; set; }

        public int? Soluongton { get; set; }

        public int? MaThuongHieu { get; set; }

        public bool TinhTrang { get; set; }
    }
}