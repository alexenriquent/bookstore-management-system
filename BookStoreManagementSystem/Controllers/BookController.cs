using System;
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
            UpdateDatabase();
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
            if (TempData["message"] == null)
                ViewBag.message = "";
            else
                ViewBag.message = TempData["message"];
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Index,Name,Author,Year,Price,Stock")] S4452232 s4452232) {
            if (ModelState.IsValid) {
                if (db.S4452232.Any(o => o.ID == s4452232.ID)) {
                    TempData["message"] = "Record already exists.";
                    return RedirectToAction("/Create");
                }
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
            if (TempData["message"] == null)
                ViewBag.message = "";
            else
                ViewBag.message = TempData["message"];
            ViewBag.books = db.S4452232.ToList();
            return View(new S4452232());
        }

        // POST: Book/DeleteBooks/
        [HttpPost]
        public ActionResult DeleteBooks(string attribute, S4452232 book) {
            switch (attribute) {
                case "index":
                    if (!db.S4452232.Any(o => o.Index == book.Index)) {
                        TempData["message"] = "Record not found.";
                        return RedirectToAction("/DeleteBooks");
                    }
                    db.S4452232.RemoveRange(db.S4452232.Where(x => x.Index == book.Index));
                    break;
                case "id":
                    if (!db.S4452232.Any(o => o.ID == book.ID)) {
                        TempData["message"] = "Record not found.";
                        return RedirectToAction("/DeleteBooks");
                    }
                    db.S4452232.RemoveRange(db.S4452232.Where(x => x.ID == book.ID));
                    break;
                case "year":
                    if (!db.S4452232.Any(o => o.Year == book.Year)) {
                        TempData["message"] = "Record not found.";
                        return RedirectToAction("/DeleteBooks");
                    }
                    db.S4452232.RemoveRange(db.S4452232.Where(x => x.Year == book.Year));
                    break;
            }
            db.SaveChanges();
            UpdateDatabase();
            SaveBooks(db.S4452232.ToList());
            return Redirect("/Book/DeleteBooks");
        }

        // GET: Book/Search
        public ActionResult Search() {
            if (TempData["books"] == null)
                ViewBag.books = new List<S4452232>();
            else
                ViewBag.books = TempData["books"];
            return View(new S4452232());
        }

        [HttpPost]
        public ActionResult Search(string attribute, S4452232 book) {
            var books = from x in db.S4452232 select x;
            switch (attribute) {
                case "id": books = books.Where(x => x.ID.Contains(book.ID)); break;
                case "name": books = books.Where(x => x.Name.Contains(book.Name)); break;
                case "author": books = books.Where(x => x.Author.Contains(book.Author)); break;
                case "year": books = books.Where(x => x.Year == book.Year); break;
            }
            TempData["books"] = books.ToList();
            return RedirectToAction("/Search");
        }
    }
}
