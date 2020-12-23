using KTX.Models;
using KTX.ViewModels;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace KTX.Controllers
{
    public class HoaDonController : BaseController
    {
        // GET: HoaDon
        public ActionResult Index(string searchString)
        {

            var hoaDon = new HoaDonModel();

            HoaDonModel hoaDonModel = new HoaDonModel();
            var hoaDonViewModels = hoaDonModel.inHoaDons();

            if (searchString == "")
            {
                SetAlert("Vui lòng nhập thông tin tìm kiếm", "error");
            }
            if (searchString != null)
            {
                hoaDonViewModels = hoaDonModel.FindHD(searchString);

            }

            return View(hoaDonViewModels);
        }

        //tạo mới
        public ActionResult Create(HOADON hoaDon)
        {
            if (ModelState.IsValid)
            {

                var hdon = new HoaDonModel();
                var hdon1 = new UserModel();
                var hdon2 = new PhongModel();
                if (hdon.Find(hoaDon.MaHD) != null)
                {
                    SetAlert("Mã hóa đơn đã tồn tại", "error");
                    return RedirectToAction("Create", "HoaDon");
                }
                if (hdon1.Find(hoaDon.MaNV) == null)
                {
                    SetAlert("Mã nhân viên không có trong CSDL", "error");
                    return RedirectToAction("Create", "HoaDon");
                }
                if (hdon2.Find(hoaDon.MaPhong) == null)
                {
                    SetAlert("Mã phòng không có trong CSDL", "error");
                    return RedirectToAction("Create", "HoaDon");
                }
                String result = hdon.Insert(hoaDon);
                if (!String.IsNullOrEmpty(result))
                {
                    SetAlert("Tạo mới hóa đơn thành công", "success");
                    return RedirectToAction("Index", "HoaDon");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo mới hóa đơn không thành công");

                }
            }
            return View();
        }
        //thêm
        public ActionResult Edit(string maHD)
        {
            var hoaDon = new HoaDonModel().GetByMaHD(maHD);
            return View(hoaDon);
        }
        [HttpPost]
        public ActionResult Edit(HOADON hoaDon)
        {
            if (ModelState.IsValid)
            {
                var hd = new HoaDonModel();
                //var hdon = new HoaDonModel();
                var hdon1 = new UserModel();
                var hdon2 = new PhongModel();
                if (hdon1.Find(hoaDon.MaNV) == null)
                {
                    SetAlert("Mã nhân viên không có trong CSDL", "error");
                    return RedirectToAction("Index", "HoaDon");
                }

                if (hdon2.Find(hoaDon.MaPhong) == null)
                {
                    SetAlert("Mã phòng không có trong CSDL", "error");
                    return RedirectToAction("Index", "HoaDon");
                }
                var result = hd.Update(hoaDon);
                if (result)
                {
                    SetAlert("Sửa hóa đơn thành công", "success");
                    return RedirectToAction("Index", "HoaDon");

                }
                else
                {
                    ModelState.AddModelError("", "Sửa hóa đơn không thành công");
                }
            }
            return View();
        }



    }
}