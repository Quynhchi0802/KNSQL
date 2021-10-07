using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KNSQL.Models;

namespace KNSQL.Controllers
{
    public class AccountController : Controller
    {
        Encrytion encry = new Encrytion();
        LapTrinhQuanLyDBContext db = new LapTrinhQuanLyDBContext();
        StringProcess strPro = new StringProcess();
        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                //mã hóa mật khẩu trc khi lưu database
                acc.password = encry.PasswordEncrytion(acc.password);
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return View(acc);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {


            if (CheckSession() == 1)

            {
                return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });

            }
            else if (CheckSession() == 2)
            {
                return RedirectToAction("Index", "Employees", new { Area = "NV" });
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Account acc, string returnUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(acc.Username) && !string.IsNullOrEmpty(acc.password))
                {
                    using (var db = new LapTrinhQuanLyDBContext())
                    {
                        var passToMD5 = strPro.GetMD5(acc.password);
                        var account = db.Accounts.Where(m => m.Username.Equals(acc.Username) && m.password.Equals(passToMD5)).Count();
                        if (account == 1)
                        {
                            FormsAuthentication.SetAuthCookie(acc.Username, false);
                            Session["idUser"] = acc.Username;
                            Session["roleUser"] = acc.RoleID;
                            return RedirectTolocal(returnUrl);
                        }
                        ModelState.AddModelError("", "thông tin đăng nhập chưa chính xác");
                    }
                }
                ModelState.AddModelError("", "Username and password is required");
            }
            catch
            {
                ModelState.AddModelError("", "hệ thống đang được bảo trì , vui lòng liên hệ với quản trị viên");
            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        //kiểm tra người dùng đăng nhập với quyền j
        private int CheckSession()
        {
            using (var db = new LapTrinhQuanLyDBContext())
            {
                var user = HttpContext.Session["idUser"];
                if (user != null)
                {
                    var role = db.Accounts.Find(user.ToString()).RoleID;
                    if (role != null)
                    {
                        if (role.ToString() == "Admin")
                        {
                            return 1;
                        }
                        else if (role.ToString() == "NV")
                        {
                            return 2;
                        }
                    }
                }
            }
            return 0;
        }
        public ActionResult RedirectTolocal(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (CheckSession() == 1)

                {
                    return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });

                }
                else if (CheckSession() == 2)
                {
                    return RedirectToAction("Index", "HomeEmp", new { Area = "Employees" });
                }

            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}