using Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KTX.Models
{
    public class PhongModel
    {
        private DBKTX db;
        public PhongModel()
        {
            db = new DBKTX();
        }

        public String MaPhong { set; get; }
        public int SoCho { set; get; }
        public String TinhTrang { set; get; }
        public String MaCTD { set; get; }
        public String MaCTN { set; get; }

        public String Insert(PHONG entityPhong)
        {
            db.PHONGs.Add(entityPhong);
            db.SaveChanges();
            return entityPhong.MaPhong;
        }

        public bool Update(PHONG entityPhong)
        {
            try
            {
                var sv = db.PHONGs.Select(x => x).Where(x => x.MaPhong == entityPhong.MaPhong).FirstOrDefault();
                sv.SoCho = Convert.ToInt32(entityPhong.SoCho.ToString());
                sv.TinhTrang = entityPhong.TinhTrang;
                sv.MaCTD = entityPhong.MaCTD;
                sv.MaCTN = entityPhong.MaCTN;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Sửa không thành công vui lòng kiểm tra lại!", e.Message);
                return false;
            }
            return true;
        }
        public PHONG getByMaPhong(string MaPhong)
        {
            return db.PHONGs.SingleOrDefault(x => x.MaPhong == MaPhong);
        }

        public PHONG Find(string MaPhong)
        {
            return db.PHONGs.Find(MaPhong);

        }

        public List<PHONG> ListAll()
        {
            return db.PHONGs.ToList();
        }
        public List<PHONG> ListWhereAll(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
                return db.PHONGs.Where(x => x.MaPhong.Contains(searchString)).ToList();
            return db.PHONGs.ToList();

        }

        public void Delete(string maPhong)
        {
            try
            {
                var phong = db.PHONGs.FirstOrDefault(x => x.MaPhong.Contains(maPhong));
                if (phong != null)
                {
                    db.PHONGs.Remove(phong);
                    db.SaveChanges();
                }
            }

            catch (Exception e)
            {
            }
        }

    }
}