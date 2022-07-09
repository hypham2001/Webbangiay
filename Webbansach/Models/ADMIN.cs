namespace Webbansach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [Key]
        [StringLength(50)]
        public string UserAdmin { get; set; }

        [StringLength(50)]
        public string PassAdmin { get; set; }

        [StringLength(50)]
        public string Hoten { get; set; }
    }
}
