using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMVCTest1.Models;

namespace WebMVCTest1.Controllers
{
    public class ContactsController : Controller
    {
        private ContactDBContext db = new ContactDBContext();

        // GET: Contacts
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDB contactDB = db.Contacts.Find(id);
            if (contactDB == null)
            {
                return HttpNotFound();
            }
            return View(contactDB);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Position,Title,Address,Tel")] ContactDB contactDB)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contactDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactDB);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDB contactDB = db.Contacts.Find(id);
            if (contactDB == null)
            {
                return HttpNotFound();
            }
            return View(contactDB);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Position,Title,Address,Tel")] ContactDB contactDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactDB);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDB contactDB = db.Contacts.Find(id);
            if (contactDB == null)
            {
                return HttpNotFound();
            }
            return View(contactDB);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactDB contactDB = db.Contacts.Find(id);
            db.Contacts.Remove(contactDB);
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
