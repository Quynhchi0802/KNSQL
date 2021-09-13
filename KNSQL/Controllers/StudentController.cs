using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KNSQL.Models;

namespace KNSQL.Controllers
{
    public class StudentController : Controller
    {
        LapTrinhQuanLyDBContext db = new LapTrinhQuanLyDBContext();
        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
        //tao action creat 
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create ( Student std)
        {
            if(ModelState.IsValid)
            {
                db.Students.Add(std);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }


        
    }
}