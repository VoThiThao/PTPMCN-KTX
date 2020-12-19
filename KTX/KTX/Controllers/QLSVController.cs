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
    public class QLSVController : BaseController
    {
        // GET: QLSV
        public ActionResult Index(string searchString)
        {
            var sv = new QLSVModel();
            if (searchString == "")
            {
                SetAlert("Vui lòng nhập nội dung tìm kiếm", "error");
            }
            var model = sv.ListWhereAll(searchString);
            @ViewBag.SearchString = searchString;
            return View(model);

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string maSV)
        {
            var sv = new QLSVModel().getByMaSV(maSV);
            return View(sv);
        }


        [HttpPost]

        public ActionResult Create(SINHVIEN sinhVien)
        {
            if (ModelState.IsValid)
            {
                var dao = new QLSVModel();
                if (dao.Find(sinhVien.MaSV) != null)
                {
                    SetAlert("Mã sinh viên đã tồn tại", "error");
                    return RedirectToAction("Create", "QLSV");
                }
                String result = dao.Insert(sinhVien);
                if (!String.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm sinh viên thành công", "success");
                    return RedirectToAction("Index", "QLSV");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sinh viên không thành công");
                }
            }
            return View();
        }


        public ActionResult Edit(SINHVIEN sinhVien)
        {
            if (ModelState.IsValid)
            {
                var dao = new QLSVModel();

                var result = dao.Update(sinhVien);
                if (result)
                {
                    SetAlert("Chỉnh sửa thông tin sinh viên thành công", "success");
                    return RedirectToAction("Index", "QLSV");
                }
                else
                {
                    ModelState.AddModelError("", "Mã sinh viên không được sửa ");
                }
            }
            return View();
        }
        public ActionResult Delete(string MaSV)
        {
            new QLSVModel().Delete(MaSV);
            SetAlert("Xóa thành công!", "success");
            return RedirectToAction("Index", "QLSV");
        }
    }
}