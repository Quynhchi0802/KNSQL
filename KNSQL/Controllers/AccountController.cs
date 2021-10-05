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
                    return RedirectToAction("Index", "Home_Ad", new { Areas = "admins" });

                }
                else if (CheckSession() == 2)
                {
                    return RedirectToAction("Index", "Home_Le", new { Areas = "NV" });
                }
            ViewBag.ReturnUrl = returnUrl;
            return View();
            
           
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Account acc)
        {
            if (ModelState.IsValid)
            {
                string encrytionpass = encry.PasswordEncrytion(acc.password);
                var model = db.Accounts.Where(m => m.Username == acc.Username && m.password == encrytionpass).ToList().Count();
                //thông tin nhập chính xác 
                if (model == 1)
                {
                    FormsAuthentication.SetAuthCookie(acc.Username, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "thông tin đăng nhập k đúng ");
                }
            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "admin")]
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
                        if (role.ToString() == "admin")
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
        public ActionResult RedirectTolocal( string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (CheckSession() == 1)

                {
                    return RedirectToAction("Index", "Home_Ad", new { Areas = "admins" });

                }
                else if (CheckSession() == 2)
                {
                    return RedirectToAction("Index", "Home_Le", new { Areas = "NV" });
                }

            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home_Ad");
            }
        }

    }
}