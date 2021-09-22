using KNSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace KNSQL.Controllers
{
    public class StdNewController : Controller
    {
        LapTrinhQuanLyDBContext db = new LapTrinhQuanLyDBContext();
        StringProcess genkey = new StringProcess();

        

        // GET: StdNew
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
        public ActionResult Create()
        {
            var stdID = "";
            var countStudent = db.Students.Count();
            if (countStudent == 0)
            {
              stdID = "STD001";
            }
            else
            {
                var StudentID = db.Students.ToList().OrderByDescending(n => n.StudentID).FirstOrDefault().StudentID;
                stdID = genkey.GenerateKey(StudentID);
            }
            ViewBag.StudentID = stdID;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student std)
        {
            if( ModelState.IsValid)
            {
                db.Students.Add(std);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(std);       
           
        }
    }
}