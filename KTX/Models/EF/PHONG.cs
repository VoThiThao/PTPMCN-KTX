namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONG")]
    public partial class PHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONG()
        {
            DIENs = new HashSet<DIEN>();
            HOADONs = new HashSet<HOADON>();
            NUOCs = new HashSet<NUOC>();
            PHONGSVs = new HashSet<PHONGSV>();
        }

        [Key]
        [StringLength(15)]
        public string MaPhong { get; set; }

        public int? SoCho { get; set; }

        [StringLength(30)]
        public string TinhTrang { get; set; }

        [Required]
        [StringLength(15)]
        public string MaCTD { get; set; }

        [Required]
        [StringLength(15)]
        public string MaCTN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEN> DIENs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NUOC> NUOCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONGSV> PHONGSVs { get; set; }
    }
}
