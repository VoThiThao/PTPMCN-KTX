using KTX.ViewModels;
using Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KTX.Models
{
    public class HoaDonModel
    {
        private DBKTX db;

        public HoaDonModel()
        {
            db = new DBKTX();
        }

        [Required(ErrorMessage = "Nhập mã hóa đơn")]
        [Display(Name = "Mã hóa đơn")]
        public string MaHD
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Nhập mã nhân viên")]
        [Display(Name = "Mã nhân viên")]
        public string MaNV
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Nhập mã phòng")]
        [Display(Name = "Mã phòng")]
        public string MaPhong
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Nhập mã ngày ghi")]
        [Display(Name = "Ngày ghi")]
        public DateTime NgayGhi
        {
            get;
            set;
        }
        public double tongTien { get; set; }
        public virtual DIEN DIEN { get; set; }
        public virtual NUOC NUOC { get; set; }


        public List<HOADON> listAll()
        {
            return db.HOADONs.ToList();
        }


        //tim hoa đơn
        public List<HoaDonViewModel> FindHD(string searchString)
        {

            var query = from i in db.HOADONs
                        join c in db.PHONGs on i.MaPhong equals c.MaPhong
                        join d in db.DIENs on c.MaPhong equals d.MaPhong
                        join e in db.NUOCs on d.MaPhong equals e.MaPhong
                        where (i.MaHD.Contains(searchString))
                        select new
                        {
                            hd = i.MaHD,
                            nv = i.MaNV,
                            mp = i.MaPhong,
                            nghi = i.NgayGhi,
                            chiSoMoiD = d.CSC,
                            chiSoCuD = d.CSD,
                            dogiaD = d.DonGia,
                            chiSoMoiN = e.CSC,
                            chiSoCuN = e.CSD,
                            donGiaN = e.DonGia,
                        };
            List<HoaDonViewModel> hd = new List<HoaDonViewModel>();

            foreach (var item in query)
            {

                HoaDonViewModel hd1 = new HoaDonViewModel();
                hd1.MaHD = item.hd;
                hd1.MaNV = item.nv;
                hd1.MaPhong = item.mp;
                hd1.NgayGhi = item.nghi;
                var tongTien = (item.chiSoMoiD - item.chiSoCuD) * item.dogiaD + (item.chiSoMoiN - item.chiSoCuN) * item.donGiaN;
                hd1.TongTien = tongTien;
                hd.Add(hd1);

            }
            //check;
            return hd;


        }

        public List<HoaDonViewModel> inHoaDons()
        {
            var query = from i in db.HOADONs
                        join c in db.PHONGs on i.MaPhong equals c.MaPhong
                        join d in db.DIENs on c.MaPhong equals d.MaPhong
                        join e in db.NUOCs on d.MaPhong equals e.MaPhong
                        select new
                        {
                            hd = i.MaHD,
                            nv = i.MaNV,
                            mp = i.MaPhong,
                            nghi = i.NgayGhi,
                            chiSoMoiD = d.CSC,
                            chiSoCuD = d.CSD,
                            dogiaD = d.DonGia,
                            chiSoMoiN = e.CSC,
                            chiSoCuN = e.CSD,
                            donGiaN = e.DonGia,
                        };
            List<HoaDonViewModel> hd = new List<HoaDonViewModel>();

            foreach (var item in query)
            {

                HoaDonViewModel hd1 = new HoaDonViewModel();
                hd1.MaHD = item.hd;
                hd1.MaNV = item.nv;
                hd1.MaPhong = item.mp;
                hd1.NgayGhi = item.nghi;
                var tongTien = (item.chiSoMoiD - item.chiSoCuD) * item.dogiaD + (item.chiSoMoiN - item.chiSoCuN) * item.donGiaN;
                hd1.TongTien = tongTien;
                hd.Add(hd1);

            }
            return hd;
        }
        public String Insert(HOADON enity)
        {
            db.HOADONs.Add(enity);
            db.SaveChanges();


            return enity.MaHD;
        }
        public HOADON Find(string maHD)
        {
            return db.HOADONs.Find(maHD);

        }

        public HOADON GetByMaHD(string maHD)
        {
            return db.HOADONs.SingleOrDefault(x => x.MaHD == maHD);
        }

        public bool Update(HOADON maHD)
        {
            try
            {
                var hd = db.HOADONs.Select(x => x).Where(x => x.MaHD == maHD.MaHD).FirstOrDefault();
                hd.MaHD = maHD.MaHD;
                hd.MaNV = maHD.MaNV;
                hd.MaPhong = maHD.MaPhong;
                hd.NgayGhi = maHD.NgayGhi;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}