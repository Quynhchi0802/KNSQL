using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KNSQL.Models;

namespace KNSQL.Controllers
{
    public class NewPersonsController : Controller
    {
        private LapTrinhQuanLyDBContext db = new LapTrinhQuanLyDBContext();
        StringProcess aukey = new StringProcess();

        // GET: NewPersons
        public ActionResult Index()
        {
            //lay gia tri ban ghi cuoi cung trong doi tuong person
            var perID = db.Persons.OrderByDescending(m => m.PersonID).FirstOrDefault().PersonID;
            var newID = aukey.GenerateKey(perID);
            ViewBag.newPerID = newID;
            return View(db.NewPersons.ToList());
        }

        // GET: NewPersons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewPerson newPerson = db.NewPersons.Find(id);
            if (newPerson == null)
            {
                return HttpNotFound();
            }
            return View(newPerson);
        }

        // GET: NewPersons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,PersonName,School,Subject")] NewPerson newPerson)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(newPerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newPerson);
        }

        // GET: NewPersons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewPerson newPerson = db.NewPersons.Find(id);
            if (newPerson == null)
            {
                return HttpNotFound();
            }
            return View(newPerson);
        }

        // POST: NewPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,PersonName,School,Subject")] NewPerson newPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newPerson);
        }

        // GET: NewPersons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewPerson newPerson = db.NewPersons.Find(id);
            if (newPerson == null)
            {
                return HttpNotFound();
            }
            return View(newPerson);
        }

        // POST: NewPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NewPerson newPerson = db.NewPersons.Find(id);
            db.Persons.Remove(newPerson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
