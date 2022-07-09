namespace Webbansach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAY")]
    public partial class GIAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIAY()
        {
            CHITIETDONTHANG = new HashSet<CHITIETDONTHANG>();
        }

        [Key]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONTHANG> CHITIETDONTHANG { get; set; }

        public virtual THUONGHIEU THUONGHIEU { get; set; }
    }
}
