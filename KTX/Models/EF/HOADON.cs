namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        [StringLength(15)]
        public string MaHD { get; set; }

        [Required]
        [StringLength(15)]
        public string MaPhong { get; set; }

        public DateTime? NgayGhi { get; set; }

        [Required]
        [StringLength(15)]
        public string MaNV { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
