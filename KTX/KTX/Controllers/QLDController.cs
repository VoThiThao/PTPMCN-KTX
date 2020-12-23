using KTX.Models;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KTX.Controllers
{
    public class QLDController : BaseController
    {
        //
        // GET: /QLD/
        public ActionResult Index(string searchString)
        {

            var dien = new QLDModel();
            if (searchString == "")
            {
                SetAlert("Vui lòng nhập nội dung tìm kiếm", "error");
            }
            var model = dien.ListWhereAll(searchString);
            @ViewBag.SearchString = searchString;
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(DIEN dien)
        {
            if (ModelState.IsValid)
            {
                var dao = new QLDModel();

                if (dao.getByMaDien(dien.MaDien) != null)
                {
                    SetAlert("Mã điện đã tồn tại", "error");
                    return RedirectToAction("Create", "QLD");
                }

                String result = dao.Insert(dien);
                if (!String.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm điện thành công", "success");
                    return RedirectToAction("Index", "QLD");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm điện không thành công");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string maDien)
        {
            var dien = new QLDModel().getByMaDien(maDien);

            return View(dien);
        }
        [HttpPost]
        public ActionResult Edit(DIEN dien)
        {
            if (ModelState.IsValid)
            {
                var dao = new QLDModel();


                var result = dao.Update(dien);
                if (result == true)
                {
                    SetAlert("Cập thông tin điện thành công", "success");
                    return RedirectToAction("Index", "QLD");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thông tin điện không thành công");
                }
            }
            return View();
        }

        public ActionResult Delete(string MaDien)
        {
            new QLDModel().Delete(MaDien);
        
            return RedirectToAction("Index", "QLD");
        }
    }
}