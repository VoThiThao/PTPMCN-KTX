using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Models.EF;

namespace KTX.Models
{
    public class QLPSVModel
    {
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Mã phòng sinh viên: ")]
        public string MaPhongSV { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Mã phòng: ")]
        public string MaPhong { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Mã sinh viên: ")]
        public string MaSV { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Thời gian bắt đầu: ")]
        public DateTime ThoiGianBĐ { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Thời gian kết thúc: ")]
        public DateTime ThoiGianKT { get; set; }

        private DBKTX db;

        public QLPSVModel()
        {
            db = new DBKTX();
        }
        public String Insert(PHONGSV entitySinhVien)
        {
            db.PHONGSVs.Add(entitySinhVien);
            try { db.SaveChanges(); }
            catch (Exception e) { Console.WriteLine("Mã sinh viên hoặc mã phòng không có trong CSDL!", e.Message); }
            return entitySinhVien.MaPhongSV;
        }

        public bool Update(PHONGSV entitySinhVien)
        {
            try
            {
                var sv = db.PHONGSVs.Select(x => x).Where(x => x.MaSV == entitySinhVien.MaSV).FirstOrDefault();
                sv.MaPhongSV = entitySinhVien.MaPhongSV;
                sv.MaPhong = entitySinhVien.MaPhong;
                sv.ThoiGianBĐ = entitySinhVien.ThoiGianBĐ;
                sv.ThoiGianKT = entitySinhVien.ThoiGianKT;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cập nhật không thành công", e.Message);
                return false;
            }
            return true;
        }

        public PHONGSV getByMaSV(string MaSV)
        {
            return db.PHONGSVs.SingleOrDefault(x => x.MaSV == MaSV);
        }

        public PHONGSV Find(string MaSV)
        {
            return db.PHONGSVs.Find(MaSV);

        }

        public List<PHONGSV> ListAll()
        {
            return db.PHONGSVs.ToList();
        }
        public List<PHONGSV> ListWhereAll(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
                return db.PHONGSVs.Where(x => x.MaSV.Contains(searchString)).ToList();
            return db.PHONGSVs.ToList();

        }

        public void Delete(string maSV)
        {
            try
            {

                var sv = db.PHONGSVs.FirstOrDefault(x => x.MaSV.Contains(maSV));
                if (sv != null)
                {
                    db.PHONGSVs.Remove(sv);
                    db.SaveChanges();

                }

            }

            catch (Exception e)
            {
                Console.WriteLine("Xóa không thành công vui lòng kiểm tra lại!", e.Message);
            }
        }
    }
}