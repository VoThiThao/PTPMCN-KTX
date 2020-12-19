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
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Mã phòng sinh viên: ")]
        [Key]
        [StringLength(15)]
        public string MaPhongSV { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Mã phòng: ")]
        [StringLength(15)]
        public string MaPhong { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Mã sinh viên: ")]
        [StringLength(15)]
        public string MaSV { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Thời gian bắt đầu: ")]
        public DateTime ThoiGianBĐ { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Thời gian kết thúc: ")]
        public DateTime ThoiGianKT { get; set; }

        public virtual PHONG PHONG { get; set; }

        public virtual SINHVIEN SINHVIEN { get; set; }
    }
}
