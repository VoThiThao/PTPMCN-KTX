using Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KTX.Models
{
    public class QLDModel
    {
        private DBKTX db;

        public QLDModel()
        {
            db = new DBKTX();
        }
        public String Insert(DIEN entityDien)
        {
            db.DIENs.Add(entityDien);
            try { db.SaveChanges(); }
            catch (Exception e)
            {
                Console.WriteLine("Mã phòng không có trong CSDL!", e.Message);
            }
            return entityDien.MaDien;
        }

        public bool Update(DIEN entityDien)
        {
            try
            {
                var dien = db.DIENs.Select(x => x).Where(x => x.MaDien == entityDien.MaDien).FirstOrDefault();

                dien.MaPhong = entityDien.MaPhong;
                dien.NgayGhi = entityDien.NgayGhi;
                dien.CSD = entityDien.CSD;
                dien.CSC = entityDien.CSC;
                dien.DonGia = entityDien.DonGia;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Sửa không thành công vui lòng kiểm tra lại!", e.Message);
                return false;
            }
            return true;
        }

        public DIEN getByMaDien(string MaDien)
        {
            return db.DIENs.SingleOrDefault(x => x.MaDien == MaDien);
        }

        public DIEN Find(string MaDien)
        {
            return db.DIENs.Find(MaDien);

        }
        public DIEN FindMaPhong(string MaPhong)
        {
            return db.DIENs.Find(MaPhong);

        }

        public List<DIEN> ListAll()
        {
            return db.DIENs.ToList();
        }
        public List<DIEN> ListWhereAll(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
                return db.DIENs.Where(x => x.MaPhong.Contains(searchString)).ToList();
            return db.DIENs.ToList();

        }

        public void Delete(string maDien)
        {
            try
            {
                var dien = db.DIENs.FirstOrDefault(x => x.MaDien.Contains(maDien));
                if (dien != null)
                {
                    db.DIENs.Remove(dien);
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
