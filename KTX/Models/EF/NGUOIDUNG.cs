namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        public NGUOIDUNG()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [StringLength(20)]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [Display(Name = "Tên đăng nhập")]
        public string TenDangNhap { get; set; }

      
        [StringLength(20)]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [Key]
        [StringLength(15)]
        [Required(ErrorMessage = "Vui lòng nhập mã nhân viên")]
        [Display(Name = "Mã nhân viên")]
        public string MaNV { get; set; }

       
        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [Display(Name = "Họ tên")]
        public string HoTenNV { get; set; }
        [Display(Name = "Chức vụ")]

        public int? ChucVu { get; set; }

       
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
