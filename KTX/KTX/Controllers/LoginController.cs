using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KTX.Models;
using Models.DAO;
using KTX.Common;
using Models.EF;


namespace KTX.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoginModel();
                var result = dao.login(user.TenDangNhap, user.MatKhau);

                if (result == null)
                {
                    ModelState.AddModelError("", "Vui lòng kiểm tra lại tài khoản");
                }

                else
                {

                    Session.Add(Constants.USER_SESSION, user);
                    Session.Add(Constants.USER_ROLE, result.ChucVu);
                    if (result.ChucVu == 1)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        return RedirectToAction("Index", "QLSVs");

                    }

                }

            }
            return View("Index");
        }
    }
}