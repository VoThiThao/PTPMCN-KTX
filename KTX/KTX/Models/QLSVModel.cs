using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Models.EF;

namespace KTX.Models
{
    public class QLSVModel
    {
        public String MaSV { set; get; }

        public String HoTen { set; get; }

        public DateTime NgaySinh { set; get; }

        public String GioiTinh { set; get; }

        public int CMND { set; get; }

        public String QueQuan { set; get; }

        public String Lop { set; get; }

        public String Khoa { set; get; }

        private DBKTX db;

        public QLSVModel()
        {
            db = new DBKTX();
        }
        public String Insert(SINHVIEN entitySinhVien)
        {
            db.SINHVIENs.Add(entitySinhVien);
            db.SaveChanges();
            return entitySinhVien.MaSV;
        }

        public bool Update(SINHVIEN entitySinhVien)
        {
            try
            {
                var sv = db.SINHVIENs.Select(x => x).Where(x => x.MaSV == entitySinhVien.MaSV).FirstOrDefault();
                sv.HoTen = entitySinhVien.HoTen;
                sv.NgaySinh = entitySinhVien.NgaySinh;
                sv.GioiTinh = entitySinhVien.GioiTinh;
                sv.CMND = entitySinhVien.CMND;
                sv.QueQuan = entitySinhVien.QueQuan;
                sv.Lop = entitySinhVien.Lop;
                sv.Khoa = entitySinhVien.Khoa;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cập nhật không thành công", e.Message);
                return false;
            }
            return true;
        }

        public SINHVIEN getByMaSV(string MaSV)
        {
            return db.SINHVIENs.SingleOrDefault(x => x.MaSV == MaSV);
        }

        public SINHVIEN Find(string MaSV)
        {
            return db.SINHVIENs.Find(MaSV);

        }

        public List<SINHVIEN> ListAll()
        {
            return db.SINHVIENs.ToList();
        }
        public List<SINHVIEN> ListWhereAll(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
                return db.SINHVIENs.Where(x => x.MaSV.Contains(searchString)).ToList();
            return db.SINHVIENs.ToList();

        }

        public void Delete(string maSV)
        {
            try
            {

                var sv = db.SINHVIENs.FirstOrDefault(x => x.MaSV.Contains(maSV));
                if (sv != null)
                {
                    db.SINHVIENs.Remove(sv);
                    db.SaveChanges();

                }

            }

            catch (Exception e)
            {
            }
        }
    }
}