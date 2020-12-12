namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NUOC")]
    public partial class NUOC
    {
        [Key]
        [StringLength(15)]
        public string MaNuoc { get; set; }

        [Required]
        [StringLength(15)]
        public string MaPhong { get; set; }

        public DateTime NgayGhi { get; set; }

        public int CSD { get; set; }

        public int CSC { get; set; }

        public double DonGia { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
