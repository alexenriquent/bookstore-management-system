using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers {

    public class BookStoreController : BaseController {

        public ActionResult GetAllBooks() {
            ViewBag.books = RetrieveBooks();
            return View();
        }

        [HttpGet]
        public ActionResult AddBook() {
            ViewBag.books = RetrieveBooks();
            return View(new Book());
        }

        [HttpPost]
        public ActionResult AddBook(Book book) {
            List<Book> books = RetrieveBooks();
            books.Add(book);
            SaveBooks(books);
            return Redirect("/BookStore/AddBook");
        }

        [HttpGet]
        public ActionResult DeleteBook() {
            ViewBag.books = RetrieveBooks();
            return View(new Book());
        }

        [HttpPost]
        public ActionResult DeleteBook(string attribute, Book book) {
            List<Book> books = RetrieveBooks();
            switch (attribute) {
                case "num": books.RemoveAll(x => x.Index == book.Index); break;
                case "id": books.RemoveAll(x => x.ID == book.ID); break;
                case "name": books.RemoveAll(x => x.Name == book.Name); break;
                case "author": books.RemoveAll(x => x.Author == book.Author); break;
                case "year": books.RemoveAll(x => x.Year == book.Year); break;
            }
            SaveBooks(books);
            return Redirect("/BookStore/DeleteBook");
        }

        [HttpGet]
        public ActionResult SearchBook() {
            if (TempData["books"] == null)
                ViewBag.books = new List<Book>();
            else
                ViewBag.books = TempData["books"];
            return View(new Book());
        }

        [HttpPost]
        public ActionResult SearchBook(string attribute, Book book) {
            List<Book> books = RetrieveBooks();
            List<Book> results = new List<Book>();
            switch (attribute) {
                case "id": results = books.FindAll(x => x.ID == book.ID); break;
                case "name": results = books.FindAll(x => x.Name == book.Name); break;
                case "author": results = books.FindAll(x => x.Author == book.Author); break;
                case "year": results = books.FindAll(x => x.Year == book.Year); break;
            }
            TempData["books"] = results;
            return RedirectToAction("/SearchBook");
        }
    }
}