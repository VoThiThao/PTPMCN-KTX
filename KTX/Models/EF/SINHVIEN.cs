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
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Mã sinh viên: ")]
        [Key]
        [StringLength(15)]
        public string MaSV { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Họ tên: ")]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Ngày sinh: ")]
        public DateTime? NgaySinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Giới tính: ")]
        [StringLength(4)]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "CMND: ")]
        public int CMND { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Quê quán: ")]
        [StringLength(50)]
        public string QueQuan { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Lớp: ")]
        [StringLength(50)]
        public string Lop { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Khoa: ")]
        [StringLength(50)]
        public string Khoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONGSV> PHONGSVs { get; set; }
    }
}
