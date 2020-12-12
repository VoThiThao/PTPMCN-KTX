namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONGSV")]
    public partial class PHONGSV
    {
        [Key]
        [StringLength(15)]
        public string MaPhongSV { get; set; }

        [Required]
        [StringLength(15)]
        public string MaPhong { get; set; }

        [Required]
        [StringLength(15)]
        public string MaSV { get; set; }

        public DateTime ThoiGianBĐ { get; set; }

        public DateTime ThoiGianKT { get; set; }

        public virtual PHONG PHONG { get; set; }

        public virtual SINHVIEN SINHVIEN { get; set; }
    }
}
