using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTX.ViewModels
{
    public class HoaDonViewModel
    {
        public string MaHD { get; set; }

        public string MaNV { get; set; }

        public string MaPhong { get; set; }

        public DateTime NgayGhi { get; set; }

        public double TongTien { get; set; }
    }
}