﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStoreManagementSystem.Models;

namespace BookStoreManagementSystem.Controllers {

    public class BookController : BaseController {

        private BookDBContext db = new BookDBContext();

        // GET: Book
        public ActionResult Index() {
            return View(db.S4452232.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(string id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            S4452232 s4452232 = db.S4452232.Find(id);
            if (s4452232 == null) {
                return HttpNotFound();
            }
            return View(s4452232);
        }

        // GET: Book/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Index,Name,Author,Year,Price,Stock")] S4452232 s4452232) {
            if (ModelState.IsValid) {
                db.S4452232.Add(s4452232);
                db.SaveChanges();
                UpdateDatabase();
                SaveBooks(db.S4452232.ToList());
                return RedirectToAction("Index");
            }
            return View(s4452232);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(string id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            S4452232 s4452232 = db.S4452232.Find(id);
            if (s4452232 == null) {
                return HttpNotFound();
            }
            return View(s4452232);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Index,Name,Author,Year,Price,Stock")] S4452232 s4452232) {
            if (ModelState.IsValid) {
                db.Entry(s4452232).State = EntityState.Modified;
                db.SaveChanges();
                SaveBooks(db.S4452232.ToList());
                return RedirectToAction("Index");
            }
            return View(s4452232);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(string id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            S4452232 s4452232 = db.S4452232.Find(id);
            if (s4452232 == null) {
                return HttpNotFound();
            }
            return View(s4452232);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id) {
            S4452232 s4452232 = db.S4452232.Find(id);
            db.S4452232.Remove(s4452232);
            db.SaveChanges();
            UpdateDatabase();
            SaveBooks(db.S4452232.ToList());
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Book/DeleteBooks
        public ActionResult DeleteBooks() {
            ViewBag.books = db.S4452232.ToList();
            return View(new S4452232());
        }

        // POST: Book/DeleteBooks/
        [HttpPost]
        public ActionResult DeleteBooks(string attribute, S4452232 book) {
            switch (attribute) {
                case "index": db.S4452232.RemoveRange(db.S4452232.Where(c => c.Index == book.Index)); break;
                case "id": db.S4452232.RemoveRange(db.S4452232.Where(c => c.ID == book.ID)); break;
                case "year": db.S4452232.RemoveRange(db.S4452232.Where(c => c.Year == book.Year)); break;
            }
            db.SaveChanges();
            UpdateDatabase();
            SaveBooks(db.S4452232.ToList());
            return Redirect("/Book/DeleteBooks");
        }
    }
}
