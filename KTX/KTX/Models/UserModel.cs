using Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KTX.Models
{
    public class UserModel
    {

        private DBKTX db;

        public UserModel()
        {
            db = new DBKTX();
        }

        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [Display(Name = "Tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mã nhân viên")]
        [Display(Name = "Mã nhân viên")]
        public string MaNV { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [Display(Name = "Họ tên")]
        public string HoTenNV { get; set; }
        [Display(Name = "Chức vụ")]
        public int? ChucVu { get; set; }

        //public List<NGUOIDUNG> ListAll()
        //{
        //    return db.NGUOIDUNGs.ToList();
        //}
        public List<NGUOIDUNG> ListWhereAll(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
                return db.NGUOIDUNGs.Where(x => x.MaNV.Contains(searchString)).ToList();
            return db.NGUOIDUNGs.ToList();


        }
        public String Insert(NGUOIDUNG entityNguoiDung)
        {

            db.NGUOIDUNGs.Add(entityNguoiDung);
            db.SaveChanges();
            return entityNguoiDung.TenDangNhap;
        }
        public NGUOIDUNG getByTenDangNhap(string TenDangNhap)
        {
            return db.NGUOIDUNGs.SingleOrDefault(x => x.TenDangNhap == TenDangNhap);
        }
        public NGUOIDUNG getByMaNV(string MaNV)
        {
            return db.NGUOIDUNGs.SingleOrDefault(x => x.MaNV == MaNV);
        }
        public bool Update(NGUOIDUNG entityNguoiDung)
        {
            try
            {
                var user = db.NGUOIDUNGs.Select(x => x).Where(x => x.TenDangNhap == entityNguoiDung.TenDangNhap).FirstOrDefault();
                user.MatKhau = entityNguoiDung.MatKhau;
                user.MaNV = entityNguoiDung.MaNV;
                user.HoTenNV = entityNguoiDung.HoTenNV;
                user.ChucVu = entityNguoiDung.ChucVu;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public NGUOIDUNG Find(string tenDN)
        {
            return db.NGUOIDUNGs.Find(tenDN);
        }


        public void Delete(string tenDangNhap)
        {
            try
            {

                var user = db.NGUOIDUNGs.FirstOrDefault(x => x.TenDangNhap.Contains(tenDangNhap));

                if (user != null)
                {
                    db.NGUOIDUNGs.Remove(user);
                    db.SaveChanges();
                }
            }

            catch (Exception e)
            {

            }
        }
    }

}