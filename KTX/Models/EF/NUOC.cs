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
        [Required(ErrorMessage = "Mã nước không được trống")]
        [Display(Name = "Mã nước")]
        public string MaNuoc { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập mã phòng")]
        [StringLength(15)]

        [Display(Name = "Mã phòng")]
        public string MaPhong { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập ngày")]
        [Display(Name = "Ngày ghi")]
        public DateTime NgayGhi { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập CSD")]
        [Display(Name = "Chỉ số đầu")]
        public int CSD { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập CSC")]
        [Display(Name = "Chỉ số cuối")]

        public int CSC { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập đơn giá")]
        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }
        public double ThanhTienN
        {
            get
            {
                return (CSC - CSD) * DonGia;
            }
        }
        public virtual PHONG PHONG { get; set; }
    }
}
