using KTX.Models;
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KTX.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        //public ActionResult Index()
        //{
        //    var user = new NguoiDungModel();
        //    var model= user.ListAll();
        //    return View(model);
        //}

        public ActionResult Index(string searchString)
        {
            if (searchString == "")
            {
                SetAlert("Vui lòng nhập nội dung tìm kiếm", "warning");
            }
            var user = new UserModel();
            var model = user.ListWhereAll(searchString);
            @ViewBag.SearchString = searchString;
            return View(model);


        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string tenDangNhap)
        {
            var user = new UserModel().getByTenDangNhap(tenDangNhap);
            return View(user);
        }


        [HttpPost]

        public ActionResult Create(NGUOIDUNG ngDung)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserModel();
                if (dao.getByTenDangNhap(ngDung.TenDangNhap) != null)
                {
                    SetAlert("Tên đăng nhập đã tồn tại", "warning");
                    return RedirectToAction("Create", "User");
                }
                if (dao.getByMaNV(ngDung.MaNV) != null)
                {
                    SetAlert("Mã nhân viên đã tồn tài trong hệ thông", "warning");
                    return RedirectToAction("Create", "User");
                }
                String result = dao.Insert(ngDung);
                if (!String.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }

                else
                {
                    ModelState.AddModelError("", "Vui lòng nhập đủ thông tin");
                }
            }
            return View();
        }


        public ActionResult Edit(NGUOIDUNG ngDung)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserModel();
                var result = dao.Update(ngDung);
                if (result == true)
                {
                    SetAlert("Cập người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mã nhân viên không được sửa");
                }
            }
            return View();
        }

        public ActionResult Delete(string TenDangNhap)
        {
            new UserModel().Delete(TenDangNhap);
            //SetAlert("Xoá thành công", "success");
            return RedirectToAction("Index", "User");
        }
    }
}