using KTX.Models;
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KTX.Controllers
{
    public class PhongController : BaseController
    {


        // GET: Phong

        public ActionResult Index(string searchString)
        {
            var sv = new PhongModel();
            if (searchString == "")
            {
                SetAlert("Vui lòng nhập thông tin tìm kiếm", "error");
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
        public ActionResult Edit(string maPhong)
        {
            var phong = new PhongModel().getByMaPhong(maPhong);
            return View(phong);
        }
        [HttpPost]

        public ActionResult Create(PHONG phong)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhongModel();
                if (dao.Find(phong.MaPhong) != null)
                {
                    SetAlert("Mã phòng này đã có trong hệ thống", "error");
                    return RedirectToAction("Create", "Phong");
                }
                String result = dao.Insert(phong);
                if (!String.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm phòng thành công", "success");
                    return RedirectToAction("Index", "Phong");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm phòng không thành công");
                }
            }
            return View();
        }
        public ActionResult Edit(PHONG phong)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhongModel();

                var result = dao.Update(phong);
                try { 
                    if (result)
                    {
                        SetAlert("Chỉnh sửa thông tin phòng thành công ", "success");
                        return RedirectToAction("Index", "Phong");
                    }
                    else
                    {
                        if (phong.SoCho > 8)
                        {
                            ModelState.AddModelError("", "Mỗi phòng chỉ có 8 chỗ!");
                        }
                        else
                            ModelState.AddModelError("", "Mã phòng không được sửa");
                    }
                }catch (Exception e)
                {
                    
                }
            }
            return View();
        }
        public ActionResult Delete(string MaPhong)
        {
            new PhongModel().Delete(MaPhong);
            return RedirectToAction("Index", "Phong");
        }

    }
}