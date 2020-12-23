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
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Mã hóa đơn ")]
        [StringLength(15)]
        public string MaHD { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Mã nhân viên ")]
        [StringLength(15)]
        public string MaNV { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Mã phòng ")]
        [StringLength(15)]
        public string MaPhong { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Ngày ghi ")]
        public DateTime NgayGhi { get; set; }
        //public double tongTien { get; set; }

        //public double TT { get; set; } = 100.1;

        //tinh tong tien

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
