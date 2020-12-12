namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SINHVIEN")]
    public partial class SINHVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SINHVIEN()
        {
            PHONGSVs = new HashSet<PHONGSV>();
        }

        [Key]
        [StringLength(15)]
        public string MaSV { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(4)]
        public string GioiTinh { get; set; }

        public int CMND { get; set; }

        [StringLength(50)]
        public string QueQuan { get; set; }

        [Required]
        [StringLength(50)]
        public string Lop { get; set; }

        [StringLength(50)]
        public string Khoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONGSV> PHONGSVs { get; set; }
    }
}
